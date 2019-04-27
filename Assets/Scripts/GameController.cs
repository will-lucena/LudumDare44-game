using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static System.Action<int> endTurn;
    private static GameProps currentProps;

    private void Awake()
    {
        currentProps = Resources.Load<GameProps>("Props/default");
    }

    public void nextTurn()
    {
        endTurn?.Invoke(1);
    }

    public static int getTotalTurns()
    {
        return currentProps.numberOfTurns;
    }
}
