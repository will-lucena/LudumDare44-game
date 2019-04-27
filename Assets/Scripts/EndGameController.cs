using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthyLabel;
    [SerializeField] private TextMeshProUGUI moneyLabel;
    [SerializeField] private TextMeshProUGUI socialLabel;
    [SerializeField] private TextMeshProUGUI knowledgeLabel;

    private void Start()
    {
        healthyLabel.text = "Health: " + GameController.results[Status.Healthy];
        moneyLabel.text = "Money: " + GameController.results[Status.Money];
        socialLabel.text = "Social: " + GameController.results[Status.Social];
        knowledgeLabel.text = "Knowledge: " + GameController.results[Status.Knowledge];
    }
}
