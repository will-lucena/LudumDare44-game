using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    private int currentTurn;
    private int totalTurns;

    private void Start()
    {
        GameController.endTurn += updateProgress;
        totalTurns = GameController.getTotalTurns();
    }

    public void updateProgress(int amount)
    {
        currentTurn += amount;
        progressBar.value = ((float) currentTurn / (float)totalTurns);
    }
}
