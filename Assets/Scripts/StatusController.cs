using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField] private Status status;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Color maxColor;
    [SerializeField] private Color minColor;
    [SerializeField] private Image foreground;

    private int currentValue;
    [SerializeField] private int maxValue;

    private void Start()
    {
        GameController.notifyCardEffect += updateStatus;
        GameController.requestResult += setResult;
        progressBar.value = 0.5f;
        currentValue = GameController.getMaxStatusValue() / 2;
        updateBar();
    }

    private void updateStatus(Status buffType, Status nerfType, int buff, int nerf)
    {
        if (status.Equals(buffType))
        {
            currentValue += buff;
        } else if (status.Equals(nerfType))
        {
            currentValue -= nerf;
        } else
        {
            return;
        }

        updateBar();
    }

    private void updateBar()
    {
        progressBar.value = (float)((float)currentValue / (float)maxValue);
        foreground.color = Color.Lerp(Color.red, Color.green, progressBar.value);
    }

    private void setResult()
    {
        GameController.results[status] = currentValue;
    }
}
