using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    
    public static Action<int> endTurn;
    public static Action<Status, Status, int, int> notifyCardEffect;

    private static GameProps currentProps;
    [SerializeField] private Stack<Card> cards; 

    private void Awake()
    {
        currentProps = Resources.Load<GameProps>("Props/default");
        Card[] array = Resources.LoadAll<Card>("Cards/");
        this.cards = new Stack<Card>();
        foreach (Card card in array)
        {
            this.cards.Push(card);
        }
    }

    public void nextTurn()
    {
        Card currentCard = cards.Pop();
        notifyCardEffect?.Invoke(currentCard.buffType, currentCard.nerfType, currentCard.buffValue, currentCard.nerfValue);
        endTurn?.Invoke(1);
    }

    public static int getTotalTurns()
    {
        return currentProps.numberOfTurns;
    }
}

public enum Status
{
    Social,
    Money,
    Healthy,
    Knowledge
}