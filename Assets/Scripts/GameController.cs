﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public static Action<int> endTurn;
    public static Action<Status, Status, int, int, bool> notifyCardEffect;
    public static Action requestResult;
    public static Hashtable results;

    private static GameProps currentProps;
    private Stack<Card> cards;
    private Card currentCard;

    [SerializeField] private TextMeshProUGUI descriptionLabel;
    [SerializeField] private Image typeOverlay;
    [SerializeField] private TextMeshProUGUI rightButton;
    [SerializeField] private TextMeshProUGUI leftButton;
    [SerializeField] private DragHandler rightSide;
    [SerializeField] private DragHandler leftSide;
    [SerializeField] private DragHandler downSide;

    private void Awake()
    {
        results = new Hashtable();
        results.Add(Status.Healthy, 0);
        results.Add(Status.Social, 0);
        results.Add(Status.Money, 0);
        results.Add(Status.Knowledge, 0);

        currentProps = Resources.Load<GameProps>("Props/default");
        Card[] array = Resources.LoadAll<Card>("Cards/");

        cards = new Stack<Card>();
        while (cards.Count < currentProps.numberOfTurns)
        {
            cards.Push(array[UnityEngine.Random.Range(1, 100) % currentProps.numberOfTurns]);
        }
    }

    private void Start()
    {
        startTurn();
    }

    private void OnEnable()
    {
        rightSide.overEvent += rightOverlay;
        rightSide.dropEvent += rightAction;

        leftSide.overEvent += leftOverlay;
        leftSide.dropEvent += leftAction;

        downSide.overEvent += downOverlay;
        downSide.dropEvent += downAction;
        CardSwipe.defaultOverlay += defaultOverlay;
    }

    private void OnDisable()
    {
        rightSide.overEvent -= rightOverlay;
        rightSide.dropEvent -= rightAction;

        leftSide.overEvent -= leftOverlay;
        leftSide.dropEvent -= leftAction;

        downSide.overEvent -= downOverlay;
        downSide.dropEvent -= downAction;
        CardSwipe.defaultOverlay -= defaultOverlay;
    }

    private void startTurn()
    {
        currentCard = cards.Pop();
        descriptionLabel.text = currentCard.description;
        rightButton.text = currentCard.buffType.ToString();
        leftButton.text = currentCard.nerfType.ToString();
    }

    public void nextTurn()
    {
        endTurn?.Invoke(1);
        if (cards.Count == 0)
        {
            requestResult?.Invoke();
            SceneManager.LoadScene("End game");
        } else {
            startTurn();
        }
        
    }

    public void rightOverlay()
    {
        typeOverlay.color = getColor(currentCard.buffType);
    }

    public void leftOverlay()
    {
        typeOverlay.color = getColor(currentCard.nerfType);
    }

    public void downOverlay()
    {
        typeOverlay.color = getColor(Status.Money);
    }

    public void defaultOverlay()
    {
        typeOverlay.color = getColor(Status.None);
    }

    public void leftAction()
    {
        notifyCardEffect?.Invoke(currentCard.nerfType, currentCard.buffType, currentCard.nerfValue, currentCard.buffValue, false);
        nextTurn();
    }

    public void rightAction()
    {   
        notifyCardEffect?.Invoke(currentCard.buffType, currentCard.nerfType, currentCard.buffValue, currentCard.nerfValue, false);
        nextTurn();
    }

    public void downAction()
    {
        notifyCardEffect?.Invoke(currentCard.buffType, currentCard.nerfType, currentCard.buffValue, currentCard.nerfValue, true);
        nextTurn();
    }

    private Color getColor(Status type)
    {
        switch (type)
        {
            case Status.Healthy:
                return currentProps.healthColor;
            case Status.Knowledge:
                return currentProps.knowledgeColor;
            case Status.Money:
                return currentProps.moneyColor;
            case Status.Social:
                return currentProps.socialColor;
            default:
                return Color.white;
        }
    }

    public static int getTotalTurns()
    {
        return currentProps.numberOfTurns;
    }

    public static int getMaxStatusValue()
    {
        return currentProps.maxStatusValue;
    }

    public static int getBaseValue()
    {
        return currentProps.baseCost;
    }

    public static int getInitialMoney()
    {
        return currentProps.initialMoney;
    }

    public static float getSaveMultiplier()
    {
        return currentProps.saveBonusMultiplier;
    }
}

public enum Status
{
    Social,
    Money,
    Healthy,
    Knowledge,
    None
}