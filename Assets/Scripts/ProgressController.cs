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
        totalTurns = GameController.getTotalTurns();
    }

    private void OnEnable()
    {
        GameController.endTurn += updateProgress;
    }

    private void OnDisable()
    {
        GameController.endTurn -= updateProgress;
    }

    public void updateProgress(int amount)
    {
        currentTurn += amount;
        progressBar.value = ((float) currentTurn / (float)totalTurns);
    }
}
