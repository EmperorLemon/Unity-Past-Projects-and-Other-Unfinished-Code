using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public int cardSum;
    public int cardsDrawn;

    [Header("Boolean Fields")]
    public bool hasFinished;
    public bool hasBust;
    public bool hasBlackjack;
    public bool hasWon;

    public double playerCash;

    //[HideInInspector]
    //public int winStreak;

    [HideInInspector]
    public GameObject cardHolder;

    [HideInInspector]
    public int randCard;

    private Game game;

    void Awake()
    {
        cardHolder = GameObject.Find("Player Cards");
        game = GetComponent<Game>();
    }

    void Start()
    {
        cardsDrawn = 0;
    }

    public void DisplayCard(int index)
    {
        Sprite sprite = Resources.Load<Sprite>("Blackjack Cards/" + game.deck[index].Front);

        GameObject newCard = new GameObject("Card: " + game.deck[index].Name);

        Image renderer = newCard.AddComponent<Image>();

        if (newCard.GetComponent<Image>() != null)
        {
            newCard.transform.SetParent(cardHolder.transform);

            newCard.transform.localScale = new Vector3(1.15f, 1.25f, 1.25f);

            if (cardsDrawn <= 0)
                newCard.transform.position = cardHolder.transform.position;
            else
                newCard.transform.position = new Vector3(cardHolder.transform.position.x + 25 * cardsDrawn, cardHolder.transform.position.y, 1);

            renderer.sprite = sprite;
        }

    }

    public void GetCardSum(int playerValue)
    {
        cardSum += playerValue;
        CheckForAce();
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
        // Player
        randCard = Random.Range(0, game.deck.Count);
    }

}
