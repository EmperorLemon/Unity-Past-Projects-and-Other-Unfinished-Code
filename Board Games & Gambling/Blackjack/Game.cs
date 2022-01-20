using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Blackjack_Table : Form
    {
        private int cashRemaining = 1000;
        private int betAmount = 0;
        private int winAmount;
        private int loseAmount;

        private int playerCardSum;
        private int dealerCardSum;

        private int playerVal;
        private int dealerVal;

        private int hitsTaken = 1;
        private int dealerMoves = 0;

        private bool gameStarted = false;

        private bool canStart;

        private bool playerBust;

        private bool isStanding;

        private bool blackjack;

        private List<Card> playerCards = new List<Card>();
        private List<Card> dealerCards = new List<Card>();

        private Random rand = new Random();

        private List<Card> deck = new List<Card>()
        {
            // Value, Name, Image
            new Card()  {value = 2, name = "Two"},
            new Card()  {value = 3, name = "Three"},
            new Card()  {value = 4, name = "Four"},
            new Card()  {value = 5, name = "Five"},
            new Card()  {value = 6, name = "Six"},
            new Card()  {value = 7, name = "Seven"},
            new Card()  {value = 8, name = "Eight"},
            new Card()  {value = 9, name = "Nine"},
            new Card()  {value = 10, name = "Ten"},
            new Card()  {value = 10, name = "Jack"},
            new Card()  {value = 10, name = "Queen"},
            new Card()  {value = 10, name = "King"},
            new Card()  {value = 11, name = "Ace"},
        };

        public Blackjack_Table()
        {
            InitializeComponent();
            warningText.Visible = true;
            warningText.Text = "";
            resultText.Text = "";

            hitButton.Enabled = false;
            hitButton.Visible = false;

            doubleDownButton.Enabled = false;
            doubleDownButton.Visible = false;

            standButton.Enabled = false;
            standButton.Visible = false;

            newGameButton.Enabled = false;
            newGameButton.Visible = false;

            startButton.Visible = false;
            startButton.Enabled = false;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            hitsTaken++;
            
            if (gameStarted)
                Hit();
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            if (!isStanding)
                Stand();

            doubleDownButton.Enabled = false;
            doubleDownButton.Visible = false;

            hitButton.Enabled = false;
            hitButton.Visible = false;

            standButton.Enabled = false;
            standButton.Visible = false;
        }

        private void DoubleDownButton_Click(object sender, EventArgs e)
        {
            DoubleDown();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!gameStarted && canStart)
            {
                StartGame();
            }
        }

        private int SelectRandomCard()
        {
            int randomCard;
            randomCard = rand.Next(0, deck.Count);
            return randomCard;
        }

        private void betInput_TextChanged(object sender, EventArgs e)
        {
            bool success = int.TryParse(betInput.Text, out betAmount);

            cashRemaining = 1000;

            if (success)
            {
                if (cashRemaining >= betAmount)
                {
                    if (betAmount >= 100 && betAmount <= 5000)
                    {
                        if (betAmount % 100 == 0)
                        {
                            canStart = true;
                            warningText.Text = "";

                            startButton.Enabled = true;
                            startButton.Visible = true;
                        }
                    }
                    else
                    {
                        warningText.Text = "Please enter a bet amount more than $100.";
                    }
                }
                else
                {
                    warningText.Text = "You cannot afford to bet this amount.";

                    startButton.Enabled = false;
                    startButton.Visible = false;
                }
            }

            winAmount = betAmount * 2;
            loseAmount = betAmount;
        }

        private void ResetGame()
        {
            label3.Enabled = true;
            label3.Visible = true;

            betInput.Enabled = true;
            betInput.Visible = true;

            newGameButton.Enabled = false;
            newGameButton.Visible = false;

            playerCards.Clear();
            dealerCards.Clear();

            playerCardSum = 0;
            dealerCardSum = 0;

            hitsTaken = 1;
            dealerMoves = 0;

            isStanding = false;
            gameStarted = false;

            blackjack = false;
            playerBust = false;

            startButton.Enabled = true;
            startButton.Visible = true;

            resultText.Text = "";
            dealerValue.Text = "";
            playerValue.Text = "";

            foreach (ListViewItem it in playerCardView.Items)
                it.Remove();

            foreach (ListViewItem it in dealerCardView.Items)
                it.Remove();
        }

        public void StartGame()
        {
            cashRemaining -= betAmount;
            cashText.Text = "Cash Remaining: " + "$" + cashRemaining.ToString();

            label3.Enabled = false;
            label3.Visible = false;

            betInput.Enabled = false;
            betInput.Visible = false;

            hitButton.Enabled = true;
            hitButton.Visible = true;

            doubleDownButton.Enabled = true;
            doubleDownButton.Visible = true;

            standButton.Enabled = true;
            standButton.Visible = true;

            playerCards.Clear();
            dealerCards.Clear();

            gameStarted = true;

            // Player Cards
            int randomCard = SelectRandomCard();
            Card firstCard = deck[randomCard];

            playerCards.Add(firstCard);
            playerCardView.Items.Add("Card 1: " + firstCard.name);

            // Dealer Cards
            int randomCard2 = SelectRandomCard();
            Card secondCard = deck[randomCard2];

            dealerCards.Add(secondCard);
            dealerCardView.Items.Add("Card 1: " + secondCard.name);

            dealerMoves++;

            GetPlayerValues();
            GetDealerValues();

            startButton.Enabled = false;
            startButton.Visible = false;
        }

        void Hit()
        {
                int randomCard = SelectRandomCard();
                Card newCard = deck[randomCard];

                playerCards.Add(newCard);
                playerCardView.Items.Add("Card " + hitsTaken + ": " + newCard.name);

                GetPlayerValues();
        }

        void Stand()
        {
            isStanding = true;

            // Dealer Move

            int randomCard = SelectRandomCard();
            Card newCard = deck[randomCard];
            dealerCards.Add(newCard);
            dealerCardView.Items.Add("Card " + (dealerMoves + 1) + ": " + newCard.name);

            while (dealerCardSum <= 16)
            {
                int randomCard2 = SelectRandomCard();
                Card newCard2 = deck[randomCard2];

                Task.Delay(2000);

                dealerMoves++;

                Task.Delay(2000);

                dealerCards.Add(newCard2);
                dealerCardView.Items.Add("Card " + (dealerMoves + 1) + ": " + newCard2.name);

                Task.Delay(2000);

                GetDealerValues();

                break;
            }

        }

        private void GetPlayerValues()
        {
            if (hitsTaken > 0)
            {
                if (!isStanding)
                    playerCardSum += playerCards[hitsTaken - 1].value;
            }

            playerValue.Text = playerCardSum.ToString();
        }

        private void GetDealerValues()
        {
            if (!isStanding)
                dealerCardSum = dealerCards[0].value;
            else
                dealerCardSum = dealerCards[0].value + dealerCards[dealerMoves].value + dealerCards[dealerMoves - 1].value;

            dealerValue.Text = dealerCardSum.ToString();
        }

        void DoubleDown()
        {

        }

        private void playerValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(playerValue.Text, out playerVal))

            playerValue.Text = playerCardSum.ToString();


            if (playerVal > 21)
            {
                playerBust = true;
                LoseGame();
            }
            
            if (isStanding)
            {
                if (playerVal < 22)
                {
                    if (playerVal == 21)
                    {
                        blackjack = true;
                        WinGame();
                    }

                    if (playerVal == 21 && dealerVal == 21)
                    {
                        resultText.ForeColor = Color.Yellow;
                        resultText.Text = "DRAW!";
                    }

                    if (playerVal == dealerVal)
                    {
                        resultText.BackColor = Color.Yellow;
                        resultText.Text = "DRAW!";
                    }

                    if (playerVal > dealerVal)
                    {
                        WinGame();
                    }

                    if (dealerVal > playerVal)
                    {
                        resultText.Text = "YOU LOSE!";
                        LoseGame();
                    }
                }
            }
        }

        private void LoseGame()
        {
            hitButton.Enabled = false;
            hitButton.Visible = false;

            doubleDownButton.Enabled = false;
            doubleDownButton.Visible = false;

            standButton.Enabled = false;
            standButton.Visible = false;

            resultText.ForeColor = Color.Red;

            if (playerBust)
                resultText.Text = "PLAYER HAS BUST WITH " + playerCardSum + "\n" + "YOU LOSE!";

            gameStarted = false;

            newGameButton.Enabled = true;
            newGameButton.Visible = true;
        }

        private void WinGame()
        {
            resultText.ForeColor = Color.Green;

            if (blackjack)
                resultText.Text = "BLACKJACK! \n" + "YOU WIN!";
            else
                resultText.Text = "YOU WIN!";

            gameStarted = false;

            newGameButton.Enabled = true;
            newGameButton.Visible = true;

            cashRemaining += winAmount;

            cashText.Text = "Cash Remaining: " + "$" + cashRemaining;
        }

        private void dealerValue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(dealerValue.Text, out dealerVal))

            if (dealerVal > 21)
            {
                resultText.Text = "DEALER HAS BUST WITH " + dealerCardSum + "\n" + "YOU WIN!";
                WinGame();
            }

            if (isStanding)
            {
                if (dealerVal < 22)
                {
                    if (dealerVal == 21)
                    {
                        resultText.Text = "DEALER HAS BLACKJACK" + "\n" + "YOU LOSE!";
                        LoseGame();
                    }

                    if (playerVal == dealerVal)
                    {
                        resultText.BackColor = Color.Yellow;
                        resultText.Text = "DRAW!";
                    }

                    if (dealerVal > playerVal)
                    {
                        resultText.Text = "YOU LOSE!";
                        LoseGame();
                    }

                    if (playerVal > dealerVal)
                    {
                        WinGame();
                    }
                }
            }
        }
    }
}
