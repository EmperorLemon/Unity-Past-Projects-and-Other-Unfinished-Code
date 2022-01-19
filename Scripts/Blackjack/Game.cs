using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Card> deck;
    public List<Chip> chips;

    public Sprite[] frontCards;
    //public Sprite[] chipImages;

    public Color[] chipColors;

    public Slider slider;

    [Header("Text Stuff")]
    public Text playerCardValue;
    public Text dealerCardValue;
    public Text playerResultText;
    public Text dealerResultText;
    public Text gameResultText;
    public Text betAmountText;
    public Text cashRemainingText;

    //public Text playerWinStreak;
    //public Text dealerWinStreak;

    public bool gameHasStarted;
    public bool canReset;

    public double cashRemaining;
    public double betAmount;

    [Header("UI Elements")]
    public GameObject startButton;
    public GameObject hitButton;
    public GameObject standButton;

    private readonly char[] cardChoices = { 'C', 'D', 'H', 'S' };
    private char randomCardChoice;

    private bool draw;

    private readonly double startingCash = 1000.00;

    private readonly bool[] xD = new bool[4];

    private Player player;
    private Dealer dealer;

    private Button startBtn;
    private Button hitBtn;
    private Button standBtn;

    void Awake()
    {
        for (int i = 0; i < xD.Length; i++)
            xD[i] = false;

        player = GetComponent<Player>();
        dealer = GetComponent<Dealer>();

        startBtn = startButton.GetComponent<Button>();
        hitBtn = hitButton.GetComponent<Button>();
        standBtn = standButton.GetComponent<Button>();
    }

    void Start()
    {
        hitBtn.interactable = false;
        standBtn.interactable = false;

        cashRemaining = startingCash;

        gameResultText.text = "";
        playerResultText.text = "";
        dealerResultText.text = "";
    }

    void Update()
    {
        CheckForBust();
        CheckCardValues();

        playerCardValue.text = "Card Value: " + player.cardSum;
        dealerCardValue.text = "Card Value: " + dealer.cardSum;

        betAmount = slider.value * 10;

        betAmountText.text = "$" + System.Math.Round(betAmount);

        cashRemainingText.text = "$" + cashRemaining;

        if (!xD[0])
        {
            if (gameHasStarted)
            {
                xD[0] = true;

                startBtn.interactable = false;

                startBtn.GetComponentInChildren<Text>().text = "Reset";

                StartCoroutine(WaitToReset(10));
            }
        }

        if (!xD[1])
        {
            if (gameHasStarted)
                if (player.hasBust)
                {
                    xD[1] = true;
                    dealer.DealerTurn(true);
                }
        }

        if (player.hasWon || dealer.hasWon)
            canReset = true;
    }

    public void StartGame()
    {
        if (!gameHasStarted)
        {
            hitBtn.interactable = true;
            standBtn.interactable = true;
            slider.gameObject.SetActive(false);
            slider.interactable = false;

            gameHasStarted = true;

            CreateDeck();

            DealCards();

            Bet(betAmount);
        }

        if (canReset)
            RestartGame();
    }

    private IEnumerator WaitToReset(int time)
    {
        yield return new WaitForSeconds(time);

        startBtn.interactable = true;

        canReset = true;
    }

    private char RandomCardChoice()
    {
        int randomNumber = Random.Range(0, cardChoices.Length);

        randomCardChoice = cardChoices[randomNumber];

        return randomCardChoice;
    }

    public void MenuOpen()
    {
        Menu.OpenMenu();
    }

    private void Bet(double amount)
    {
        cashRemaining -= amount;
    }

    public void CreateDeck()
    {
        player.deck.Clear();
        dealer.deck.Clear();

        deck = new List<Card>()
        {
            new Card() {Value = 2, Name = "Two", Front = "2" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 3, Name = "Three", Front = "3" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 4, Name = "Four", Front = "4" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 5, Name = "Five", Front = "5" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 6, Name = "Six", Front = "6" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 7, Name = "Seven", Front = "7" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 8, Name = "Eight", Front = "8" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 9, Name = "Nine", Front = "9" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 10, Name = "Ten", Front = "10" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 10, Name = "Jack", Front = "J" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 10, Name = "Queen", Front = "Q" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 10, Name = "King", Front = "K" + RandomCardChoice(), Back = "back"},
            new Card() {Value = 11, Name = "Ace", Front = "A" + RandomCardChoice(), Back = "back"}
        };
    }

    public void DealCards()
    {
        player.GetRandomCard();
        dealer.GetRandomCard();

        Card newCard = deck[player.randCard];

        Card newCard1 = deck[dealer.randCard];
        Card newCard2 = deck[dealer.randCard2];

        // Reveal first card
        dealer.DisplayCard(dealer.randCard);

        dealer.deck.Add(newCard1);

        // Hide second card

        dealer.cardsDrawn++;

        dealer.DisplayHiddenCard(dealer.randCard2, false);

        dealer.deck.Add(newCard2);

        dealer.GetCardSum(dealer.deck[dealer.cardsDrawn - 1].Value);

        // Player Section

        player.DisplayCard(player.randCard);

        player.deck.Add(newCard);

        player.GetCardSum(player.deck[player.cardsDrawn].Value);
    }

    public void Hit()
    {
        player.cardsDrawn++;

        player.GetRandomCard();

        Card newCard = deck[player.randCard];

        player.deck.Add(newCard);

        player.DisplayCard(player.randCard);

        player.GetCardSum(player.deck[player.cardsDrawn].Value);
    }

    public void Stand()
    {
        if (gameHasStarted)
        {
            player.hasFinished = true;

            hitButton.GetComponent<Button>().interactable = false;
            standButton.GetComponent<Button>().interactable = false;

            dealer.DealerTurn(false);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Blackjack");
    }

    public void DoubleDown()
    {
        // TODO: ADD CASH!
    }

    public void CheckForBust()
    {
        if (player.cardSum > 21)
            player.hasBust = true;

        if (dealer.cardSum > 21)
            dealer.hasBust = true;
    }

    public void CheckCardValues()
    {
        if (player.hasFinished && dealer.hasFinished)
        {
            if (player.cardSum == dealer.cardSum)
            {
                draw = true;
            }
        }

        if (player.hasFinished && dealer.hasFinished)
        {
            if (!player.hasBust)
            {
                if (player.cardSum > dealer.cardSum)
                {
                    player.hasWon = true;
                }
            }

            if (!dealer.hasBust)
            {
                if (dealer.cardSum > player.cardSum)
                {
                    dealer.hasWon = true;
                }
            }
        }

        if (player.cardSum == 21)
            player.hasBlackjack = true;
        else if (dealer.cardSum == 21)
            dealer.hasBlackjack = true;

        DisplayResults();
    }

    public void DisplayResults()
    {
        if (player.hasBlackjack)
        {
            playerResultText.horizontalOverflow = HorizontalWrapMode.Overflow;
            playerResultText.text = "BLACKJACK!";
            playerResultText.color = Color.green;
        }
        else if (dealer.hasBlackjack)
        {
            dealerResultText.horizontalOverflow = HorizontalWrapMode.Overflow;
            dealerResultText.text = "BLACKJACK!";
            dealerResultText.color = Color.green;
        }

        if (draw)
        {
            gameResultText.text = "DRAW!";
            gameResultText.color = Color.yellow;
            canReset = true;
        }

        if (player.hasBust)
        {
            hitBtn.interactable = false;
            standBtn.interactable = false;

            playerResultText.text = "Player has Bust!";
            gameResultText.text = "YOU LOSE!";

            playerResultText.color = Color.red;
            gameResultText.color = Color.red;

            dealer.hasWon = true;
            canReset = true;
        }
        else if (dealer.hasBust)
        {
            dealerResultText.text = "Dealer has Bust!";
            gameResultText.text = "YOU WIN!";

            dealerResultText.color = Color.red;
            gameResultText.color = Color.green;

            player.hasWon = true;
            canReset = true;
        }

        if (player.hasWon || dealer.hasWon)
        {
            if (player.hasWon)
            {
                gameResultText.text = "YOU WIN!";
                gameResultText.color = Color.green;

                if (!xD[2])
                {
                    //player.winStreak++;
                    xD[2] = true;
                }
            }
            else if (dealer.hasWon)
            {
                gameResultText.text = "YOU LOSE!";
                gameResultText.color = Color.red;

                dealerResultText.text = "Dealer has Won";
                dealerResultText.color = Color.green;

                if (!xD[3])
                {
                    //dealer.winStreak++;
                    xD[3] = true;
                }
            }
        }
    }

    /*
    public void TestCardDisplay(bool isActive)
    {
        if (isActive)
        {
            float x = 0;

            for (int i = 0; i < frontCards.Length; i++)
            {
                GameObject newCard = new GameObject("Card: " + frontCards[i].name);
                cards.Add(newCard);
                Image renderer = cards[i].AddComponent<Image>();

                x += 100;

                newCard.transform.SetParent(canvas.transform);
                newCard.transform.SetParent(cardHolder.transform);

                cardHolder.transform.localPosition = new Vector3(-425, -100, 1);

                newCard.transform.localPosition = new Vector3(x, 0, 10);
                newCard.transform.localScale = new Vector3(0.75f, 1, 1);
                renderer.sprite = frontCards[i];
            }

        }
    }
    
    public void DirCount()
    {
        int count = 0;

        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Cards");

        FileInfo[] fis = dir.GetFiles();

        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase))
                count++;
        }
    }
    */
}
