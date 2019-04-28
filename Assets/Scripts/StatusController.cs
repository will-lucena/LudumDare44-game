using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField] private Status status;
    [SerializeField] private Color maxColor;
    [SerializeField] private Color minColor;
    [SerializeField] private Image foreground;

    private int currentValue;
    private int maxValue;

    private void Start()
    {
        foreground.fillAmount = 0.5f;
        maxValue = GameController.getMaxStatusValue();
        currentValue = maxValue / 2;
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
                GameController.results[status] = ((int)GameController.results[status]) + 1;
            } else if (status.Equals(buffType))
            {
                Debug.Log(status);
                currentValue -= buff;
                GameController.results[status] = ((int)GameController.results[status]) - 1;
            }
            else if (status.Equals(nerfType))
            {
                Debug.Log(status);
                currentValue -= nerf;
                GameController.results[status] = ((int)GameController.results[status]) - 1;
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
                GameController.results[status] = ((int) GameController.results[status]) + 1;
            }
            else if (status.Equals(nerfType))
            {
                currentValue -= nerf;
                GameController.results[status] = ((int)GameController.results[status]) - 1;
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
        float fillAmount = (float)((float)currentValue / (float)maxValue);
        foreground.fillAmount = fillAmount > 1? 1 : fillAmount;
        if (foreground)
        {
            foreground.color = Color.Lerp(minColor, maxColor, foreground.fillAmount);
        }
    }

    private void setResult()
    {
        GameController.results[status] = currentValue;
    }
}
