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
        progressBar.value = 0.5f;
        currentValue = GameController.getMaxStatusValue() / 2;
        updateBar();
    }

    private void OnEnable()
    {
        GameController.notifyCardEffect += updateStatus;
        GameController.requestResult += setResult;
    }

    private void OnDisable()
    {
        GameController.notifyCardEffect -= updateStatus;
        GameController.requestResult -= setResult;
    }

    private void updateStatus(Status buffType, Status nerfType, int buff, int nerf, bool saveOption)
    {
        if (saveOption)
        {
            if (status.Equals(Status.Money))
            {
                Debug.Log(status);
                currentValue += buff;
            } else if (status.Equals(buffType))
            {
                Debug.Log(status);
                currentValue -= buff;
            }
            else if (status.Equals(nerfType))
            {
                Debug.Log(status);
                currentValue -= nerf;
            }
            else
            {
                return;
            }
        } else
        {
            if (status.Equals(buffType))
            {
                currentValue += buff;
            }
            else if (status.Equals(nerfType))
            {
                currentValue -= nerf;
            }
            else
            {
                return;
            }
        }
        updateBar();
    }

    private void updateBar()
    {
        progressBar.value = (float)((float)currentValue / (float)maxValue);
        if (foreground)
        {
            foreground.color = Color.Lerp(Color.red, Color.green, progressBar.value);
        }
    }

    private void setResult()
    {
        GameController.results[status] = currentValue;
    }
}
