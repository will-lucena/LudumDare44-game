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
        this.progressBar.value = 0.5f;
        this.currentValue = maxValue / 2;
    }

    private void updateStatus(Status buffType, Status nerfType, int buff, int nerf)
    {
        if (status.Equals(buffType))
        {
            this.currentValue += buff;
        } else if (status.Equals(nerfType))
        {
            this.currentValue -= nerf;
        } else
        {
            return;
        }

        updateBar();
    }

    private void updateBar()
    {
        this.progressBar.value = (float)((float)this.currentValue / (float)this.maxValue);
        foreground.color = Color.Lerp(Color.red, Color.green, this.progressBar.value);
    }
}
