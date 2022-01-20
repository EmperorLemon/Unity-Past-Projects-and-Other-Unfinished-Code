using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class UnoGame : MonoBehaviour
{
    public GameObject panel;

    [Header("Card Holders")]
    public Transform centreCardHolder;
    public Transform playerCardHolder;
    public Transform opponentCardHolder;
    public Transform cardHolder;

    [Header("Card Displays")]
    public Sprite hiddenCard;

    // Number Cards: There should be 76 of them in total
    [Header("Number Cards")]
    public int blueCards = 19;
    public int greenCards = 19;
    public int redCards = 19;
    public int yellowCards = 19;

    // Power Cards: There should be 24 of them in total
    [Header("Power Cards")]
    public int skipCards = 8;
    public int reverseCards = 8;
    public int drawTwoCards = 8;

    // Wild Cards: There should be 8 of them in total
    [Header("Wild Cards")]
    public int wildCards = 4;
    public int wildDrawFourCards = 4;

    [Header("More Card Shit")]
    public int cardsAddedToDeck = 0;
    public string midColor;
    public string midValue;
    public string newColor;

    [HideInInspector]
    public Image imageColor;

    [Header("Uno Cards")]
    public List<GameObject> playerDeck = new List<GameObject>();
    public List<GameObject> centreDeck = new List<GameObject>();
    public List<GameObject> opponentDeck = new List<GameObject>();

    private List<GameObject> cardsDisplay = new List<GameObject>();
    private List<UnoCard> deck = new List<UnoCard>();

    private readonly List<UnoCard> unoCards = new List<UnoCard>();

    private readonly int centreDeckSize = 1;
    private readonly int playerDeckSize = 5;
    private readonly int opponentDeckSize = 5;

    private string cardName;

    private readonly string[] cardColors = { "blue", "green", "red", "yellow" };
    private readonly string[] wildOnes = { "colorchanger", "pickfour" };
    private readonly string[] powers = { "skip", "reverse", "picker" };
    private readonly string[] cardValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

    private void Start()
    {
        InitializeUnoCards();
        CreateCards();

        CreateCentreDeck();
        CreatePlayerDeck();
        CreateOpponentDeck();
    }

    public void InitializeUnoCards()
    {
        unoCards.Clear();

        for (int x = 0; x < cardColors.Length; x++)
            for (int y = 0; y < cardValues.Length; y++)
                unoCards.Add(new UnoCard() { Color = cardColors[x], Value = cardValues[y], Hidden = true});

        for (int x = 0; x < wildOnes.Length; x++)
            unoCards.Add(new UnoCard() { Color = "wild", Value = wildOnes[x], Hidden = true});

        for (int x = 0; x < cardColors.Length; x++)
            for (int y = 0; y < powers.Length; y++)
                unoCards.Add(new UnoCard() { Color = cardColors[x], Value = powers[y], Hidden = true});
    }

    public void CreateCards()
    {
        foreach (UnoCard c in unoCards)
        {
            for (int i = 0; i < 2; i++)
            {
                if (c.Value == "skip" || c.Value == "reverse" || c.Value == "picker")
                    deck.Add(new UnoCard() { Color = c.Color, Value = c.Value, Hidden = c.Hidden });

                if (int.TryParse(c.Value, out _))
                    deck.Add(new UnoCard() { Color = c.Color, Value = c.Value, Hidden = c.Hidden });
            }

            for (int i = 0; i < 4; i++)
                if (c.Value == "colorchanger" || c.Value == "pickfour")
                    deck.Add(new UnoCard() { Color = c.Color, Value = c.Value, Hidden = c.Hidden });
        }

        HideCardDisplay();
    }

    public void ChangeColor(string color)
    {
        panel.SetActive(false);

        GameObject cloneCard = new GameObject();

        MiddleCard midCard;

        midCard = cloneCard.AddComponent<MiddleCard>();

        imageColor = cloneCard.AddComponent<Image>();

        midCard.color = null;

        midCard.value = null;

        cloneCard.name = "Empty " + color + " " + "card";

        newColor = color;

        switch (color)
        {
            case "red":
                imageColor.color = new Color32(245, 100, 100, 255);
                break;
            case "green":
                imageColor.color = new Color32(46, 226, 154, 255);
                break;
            case "blue":
                imageColor.color = new Color32(0, 194, 229, 255);
                break;
            case "yellow":
                imageColor.color = new Color32(246, 227, 89, 255);
                break;
        }

        cloneCard.transform.localScale = new Vector2(1f, 1.35f);

        cloneCard.transform.SetParent(centreCardHolder);
        cloneCard.transform.position = centreCardHolder.position;

        AddToMiddleCardDeck(cloneCard);
    }

    public IEnumerator RemoveImage(Image img)
    {
        yield return new WaitForSeconds(2f);

        img.enabled = false;
    }

    public void AddToMiddleCardDeck(GameObject obj)
    {
        centreDeck.Add(obj);
    }

    public void CountCards()
    {
        int wildCount = 0, actionCount = 0, numberCount = 0;

        foreach (UnoCard c in deck)
        {
            if (int.TryParse(c.Value, out int convertedValue))
                numberCount++;
           
            if (c.Value == "colorchanger" || c.Value == "pickfour")
                wildCount++;

            if (c.Value == "skip" || c.Value == "reverse" || c.Value == "picker")
                actionCount++;
        }

        print("Wild Cards: " + wildCount);
        print("Action Cards: " + actionCount);
        print("Number Cards: " + numberCount);
    }

    public Sprite GetCardImage(string name)
    {
        Sprite cards;

        cards = Resources.Load<Sprite>("Uno Cards/" + name);

        return cards;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("UNO");
    }

    public void HideCardDisplay()
    {
        Image image;

        foreach (UnoCard c in deck)
        {
            cardName = c.Color + "_" + c.Value + "_" + "large";

            GetCardImage(cardName);

            cardsDisplay.Add(new GameObject("Card: " + FixName(cardName)));

            for (int i = 0; i < cardsDisplay.Count; i++)
            {
                if (cardsDisplay[i].GetComponent<Image>() != null)
                    continue;
                else
                    image = cardsDisplay[i].AddComponent<Image>();

                image.sprite = hiddenCard;

                deck[i].CardObject = cardsDisplay[i].gameObject;

                cardsDisplay[i].transform.localScale = new Vector2(0.95f, 1.25f);
                cardsDisplay[i].transform.SetParent(cardHolder);
                cardsDisplay[i].transform.position = cardHolder.position;
            }
        }
    }

    public void RemoveFromCardsDeck(int index)
    {
        cardsDisplay.RemoveAt(index);
        deck.RemoveAt(index);
    }

    public string ConvertName(string cName)
    {
        string tempName;

        tempName = cName.Replace("Player Card: ", "");
        tempName = tempName.Replace(" ", "_");
        tempName += "large";

        return tempName;
    }

    public string ConvertOtherName(string cName)
    {
        string tempName;

        tempName = cName.Replace("Centre Card: ", "");
        tempName = tempName.Replace(" ", "_");
        tempName += "large";

        return tempName;
    }

    public string FixName(string cName)
    {
        string tempName;

        tempName = cName.Replace("_", " ");
        tempName = tempName.Replace("_", "");
        tempName = tempName.Replace("large", "");

        return tempName;
    }

    public void DetermineColor(string color)
    {
        switch (color)
        {
            case "red":
                newColor = "red";
                print("Player has selected red");
                break;
            case "green":
                newColor = "green";
                print("Player has selected green");
                break;
            case "blue":
                newColor = "blue";
                print("Player has selected blue");
                break;
            case "yellow":
                newColor = "yellow";
                print("Player has selected yellow");
                break;
        }
    }

    public void CreatePlayerDeck()
    {
        Sprite card;
        Image image;

        string tempName;
        int randomCard;

        playerDeck.Clear();

        for (int i = 0; i < playerDeckSize; i++)
        {
            randomCard = ChooseRandomCard();

            if (cardsDisplay[randomCard] == null)
            {
                randomCard = ChooseRandomCard();
                print("Player Deck Error");
            }

            playerDeck.Add(cardsDisplay[randomCard]);

            image = playerDeck[i].GetComponent<Image>();

            playerDeck[i].AddComponent<EventTrigger>();
            playerDeck[i].AddComponent<CardControl>();

            playerDeck[i].name = "Player " + cardsDisplay[randomCard].name;
            tempName = ConvertName(playerDeck[i].name);
            card = GetCardImage(tempName);

            image.sprite = card;

            if (cardsDisplay[randomCard] != null)
                RemoveFromCardsDeck(randomCard);

            playerDeck[i].transform.SetParent(playerCardHolder);
            playerDeck[i].transform.position = playerCardHolder.position;
            playerDeck[i].transform.localPosition += new Vector3(100 * i, 0, 0);
        }
    }

    public void CreateCentreDeck()
    {
        Sprite card;

        Image image;

        string tempName;

        int randomCard;

        centreDeck.Clear();

        for (int i = 0; i < centreDeckSize; i++)
        {
            randomCard = ChooseRandomCard();

            if (cardsDisplay[randomCard] == null)
            {
                randomCard = ChooseRandomCard();
                print("Centre Deck Error");
            }

            if (cardsDisplay[randomCard].name.Contains("wild"))
            {
                randomCard = ChooseRandomCard();
                centreDeck.Add(cardsDisplay[randomCard]);
            }
            else
                centreDeck.Add(cardsDisplay[randomCard]);

            image = centreDeck[i].GetComponent<Image>();
            centreDeck[i].AddComponent<MiddleCard>();

            centreDeck[i].name = "Centre " + cardsDisplay[randomCard].name;
            tempName = ConvertOtherName(centreDeck[i].name);
            card = GetCardImage(tempName);

            image.sprite = card;

            RemoveFromCardsDeck(randomCard);

            centreDeck[i].transform.SetParent(centreCardHolder);
            centreDeck[i].transform.position = centreCardHolder.position;
        }
    }

    public void CreateOpponentDeck()
    {
        int randomCard;

        opponentDeck.Clear();

        for (int i = 0; i < opponentDeckSize; i++)
        {
            randomCard = ChooseRandomCard();

            if (cardsDisplay[randomCard] == null)
            {
                randomCard = ChooseRandomCard();
                print("Opponent Deck Error");
            }

            opponentDeck.Add(cardsDisplay[randomCard]);

            opponentDeck[i].name = "Opponent " + cardsDisplay[randomCard].name;
            RemoveFromCardsDeck(randomCard);

            opponentDeck[i].transform.SetParent(opponentCardHolder);
            opponentDeck[i].transform.position = opponentCardHolder.position;
            opponentDeck[i].transform.localPosition += new Vector3(100 * i, 0, 0);
        }
    }

    public void AddCardToPlayerDeck()
    {
        int randomCard;

        randomCard = ChooseRandomCard();
        playerDeck.Add(cardsDisplay[randomCard]);

        RemoveFromCardsDeck(randomCard);
    }

    public int ChooseRandomCard()
    {
        int randomCard = Random.Range(0, deck.Count);

        return randomCard;
    }
}
