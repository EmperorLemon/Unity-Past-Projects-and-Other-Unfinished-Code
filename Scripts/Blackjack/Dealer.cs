using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<GameObject> cards = new List<GameObject>();

    public int cardSum;
    public int cardsDrawn;

    [Header("Boolean Fields")]
    public bool hasFinished;
    public bool hasBust;
    public bool hasBlackjack;
    public bool hasWon;

    [HideInInspector]
    public int winStreak;

    [HideInInspector]
    public GameObject cardHolder;

    [HideInInspector]
    public int randCard, randCard2, randCard3;

    private Game game;

    void Awake()
    {
        cardHolder = GameObject.Find("Dealer Cards");
        game = GetComponent<Game>();
    }

    void Start()
    {
        cardsDrawn = 0;
    }

    public void DealerTurn(bool playerBust)
    {
        cardsDrawn++;

        DisplayHiddenCard(randCard2, true);

        GetCardSum(deck[cardsDrawn - 1].Value);

        if (!playerBust)
            StartCoroutine(ContinueDealing());
    }

    // Display only for card 2, switching between showing the card and hiding it.
    public void DisplayHiddenCard(int index, bool removeHidden)
    {
        Sprite frontSide, backSide;

        frontSide = Resources.Load<Sprite>("Blackjack Cards/" + game.deck[index].Front);
        backSide = Resources.Load<Sprite>("Blackjack Cards/" + game.deck[index].Back);

        if (!removeHidden)
            cards.Add(new GameObject("Card: " + game.deck[index].Name + " (Hidden) "));
        else
        {
            cards.RemoveAt(cardsDrawn - 1);

            // Destroy the card object that was hidden
            Destroy(GameObject.Find("Card: " + game.deck[index].Name + " (Hidden) "));

            // Create the card object that is now revealed
            cards.Add(new GameObject("Card: " + game.deck[index].Name));
        }

        Image renderer;

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<Image>() == null)
            {
                renderer = cards[i].AddComponent<Image>();

                cards[i].transform.SetParent(cardHolder.transform);

                cards[i].transform.localScale = new Vector3(1.15f, 1.25f, 1.25f);

                if (!removeHidden)
                    renderer.sprite = backSide;
                else
                    renderer.sprite = frontSide;

                if (cardsDrawn == 2)
                    cards[i].transform.position = new Vector3(cardHolder.transform.position.x + 15 * cardsDrawn, cardHolder.transform.position.y, 1);
                else
                    cards[i].transform.position = new Vector3(cardHolder.transform.position.x + 20 * cardsDrawn, cardHolder.transform.position.y, 1);

                //if (removeHidden)
                //else
                    //cards[i].transform.position = new Vector3(cardHolder.transform.position.x + 10 * cardsDrawn, cardHolder.transform.position.y, 1);
            }
        }
    }

    // Shows cards 1, 3, 4, etc.
    // Cards drawn at card 1  = 0, card 2 = 1, card 3 = 2, card 4 = 3, etc.
    public void DisplayCard(int index)
    {
        Sprite frontSide;

        frontSide = Resources.Load<Sprite>("Blackjack Cards/" + game.deck[index].Front);

        cards.Add(new GameObject("Card: " + game.deck[index].Name));
        
        Image renderer;

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<Image>() != null)
                continue;
            else
                renderer = cards[i].AddComponent<Image>();

            if (cards[i].GetComponent<Image>() != null)
            {
                cards[i].transform.SetParent(cardHolder.transform);

                cards[i].transform.localScale = new Vector3(1.15f, 1.25f, 1.25f);

                renderer.sprite = frontSide;

                // if the first card is drawn

                if (cardsDrawn == 0)
                    cards[i].transform.position = cardHolder.transform.position;
                else if (cardsDrawn > 1)
                    cards[i].transform.position = new Vector3(cardHolder.transform.position.x + 20 * cardsDrawn, cardHolder.transform.position.y, 1);
            }
        }
        
    }

    public int GetCardSum(int dealerValue)
    {
        cardSum += dealerValue;

        CheckForAce();

        return cardSum;
    }

    public void CheckForAce()
    {
        int aceCount = 0;

        foreach (Card c in deck)
        {
            if (c.Value == 11 && aceCount < 1)
            {
                aceCount++;
            }
            else if (c.Value == 11 && aceCount >= 1)
            {
                cardSum -= 10;
            }
        }

    }

    public void GetRandomCard()
    {
        randCard = Random.Range(0, game.deck.Count);

        randCard2 = Random.Range(0, game.deck.Count);

        randCard3 = Random.Range(0, game.deck.Count);
    }


    public IEnumerator ContinueDealing()
    {
        while (cardSum < 18)
        {
            cardsDrawn++;

            GetRandomCard();

            yield return new WaitForSeconds(1.5f);

            Card newCard = game.deck[randCard3];

            deck.Add(newCard);

            DisplayCard(randCard3);

            GetCardSum(deck[cardsDrawn - 1].Value);
        }

        hasFinished = true;
    }
}
