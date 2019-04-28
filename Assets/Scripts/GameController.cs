using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public static Action<int> endTurn;
    public static Action<Status, Status, int, int> notifyCardEffect;
    public static Action requestResult;
    public static Hashtable results;

    private static GameProps currentProps;
    private Stack<Card> cards;
    private Card currentCard;

    [SerializeField] private TextMeshProUGUI descriptionLabel;
    [SerializeField] private TextMeshProUGUI rightButton;
    [SerializeField] private TextMeshProUGUI leftButton;
    [SerializeField] private DragHandler rightSide;
    [SerializeField] private DragHandler leftSide;

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

    private void OnDestroy()
    {
        rightSide.overEvent -= rightAction;
        leftSide.overEvent -= leftAction;
    }

    private void OnEnable()
    {
        rightSide.overEvent += rightAction;
        leftSide.overEvent += leftAction;
    }

    private void OnDisable()
    {
        rightSide.overEvent -= rightAction;
        leftSide.overEvent -= leftAction;
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

    public void leftAction()
    {
        notifyCardEffect?.Invoke(currentCard.nerfType, currentCard.buffType, currentCard.nerfValue, currentCard.buffValue);
        nextTurn();
    }

    public void rightAction()
    {
        notifyCardEffect?.Invoke(currentCard.buffType, currentCard.nerfType, currentCard.buffValue, currentCard.nerfValue);
        nextTurn();
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
}

public enum Status
{
    Social,
    Money,
    Healthy,
    Knowledge
}