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
        this.totalTurns = GameController.getTotalTurns();
        Debug.Log(totalTurns);
    }

    public void updateProgress(int amount)
    {
        this.currentTurn += amount;
        this.progressBar.value = ((float) this.currentTurn / (float)this.totalTurns);
    }
}
