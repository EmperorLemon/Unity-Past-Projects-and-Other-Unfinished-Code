using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CardControl : EventTrigger, ISelectHandler, IDeselectHandler
{
    public string color;
    public string value;

    public bool canAdd;
    public bool isDraggable;

    private Outline outline;

    private UnoGame game;
    private MiddleCard midCard;

    private Vector2 startPos;
    private Vector2 midPos;

    private bool isDragging;
    private bool isNear;

    private float dist;

    private bool lol = false;

    private void Start()
    {
        startPos = transform.position;
        game = FindObjectOfType<UnoGame>();

        GetMiddleCard();

        isDraggable = true;
    }

    public void GetCardValue()
    {
        string[] splitWords;
        char[] splitters = { ' ' };
        string tempName;

        tempName = gameObject.name;
        tempName = tempName.Replace("Player Card: ", "");
        splitWords = tempName.Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        color = splitWords[0];
        value = splitWords[1];
    }

    public void GetMiddleCard()
    {
        midCard = game.centreDeck[game.cardsAddedToDeck].GetComponent<MiddleCard>();

        midCard.GetCardValue();

        game.midColor = midCard.color;
        game.midValue = midCard.value;

        midPos = midCard.gameObject.transform.position;
    }

    public void CheckValues()
    {
        string[] wildCards = { "pickfour", "colorchanger" };

        // print("Old Middle Card: " + game.midColor + " " + game.midValue);
        // print("Old Player Card: " + color + " " + value);

        if (color == game.midColor || value == game.midValue ||
            value.Contains(wildCards[0]) || value.Contains(wildCards[1]) || color == game.newColor)
        {
            if (value.Contains(wildCards[0]) || value.Contains(wildCards[1]))
            {
                game.panel.SetActive(true);
                lol = false;
            }

            if (isNear)
                canAdd = true;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        eventData.selectedObject = gameObject;
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);

        HighlightObject(gameObject);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);

        UnHiglightObject();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        GetCardValue();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        isDragging = true;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        isDragging = false;

        CheckValues();

        if (canAdd)
            AddToMiddleDeck();
    }

    public void AddToMiddleDeck()
    {
        CardControl control;

        GameObject cloneCard = gameObject;

        cloneCard.AddComponent<MiddleCard>();

        control = cloneCard.GetComponent<CardControl>();

        game.centreDeck.Add(cloneCard);
        game.playerDeck.Remove(gameObject);

        game.cardsAddedToDeck++;

        UnHiglightObject();
        control.isDraggable = false;
        control.enabled = false;

        cloneCard.transform.SetParent(game.centreCardHolder);

        SwapValues(control);
    }

    public void SwapValues(CardControl control)
    {
        game.midColor = control.color;
        game.midValue = control.value;

        //print("New Middle Card: " + control.color + " " + control.value);
    }

    public void HighlightObject(GameObject obj)
    {
        if (obj.GetComponent<Outline>() == null)
        {
            outline = obj.AddComponent<Outline>();
            outline.effectColor = Color.yellow;
            outline.effectDistance = new Vector2(4, 4);
        }
        else
            outline.enabled = true;
    }

    public void UnHiglightObject()
    {
        outline.enabled = false;
    }

    private void Update()
    {
        if (isDraggable)
        {
            if (isDragging)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                dist = Vector2.Distance(midPos, transform.position);

                if (dist < 60)
                    isNear = true;
                else
                    isNear = false;
            }
            else
                transform.position = startPos;
        }

        if (!lol)
        {
            switch (game.newColor)
            {
                case "red":
                    game.ChangeColor(game.newColor);
                    lol = true;
                    break;
                case "green":
                    game.ChangeColor(game.newColor);
                    lol = true;
                    break;
                case "blue":
                    game.ChangeColor(game.newColor);
                    lol = true;
                    break;
                case "yellow":
                    game.ChangeColor(game.newColor);
                    lol = true;
                    break;
            }

            lol = true;
        }

    }
}
