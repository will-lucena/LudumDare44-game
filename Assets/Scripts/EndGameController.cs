using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rent;
    [SerializeField] private TextMeshProUGUI college;
    [SerializeField] private TextMeshProUGUI transport;
    [SerializeField] private TextMeshProUGUI netflix;
    [SerializeField] private TextMeshProUGUI food;
    [SerializeField] private TextMeshProUGUI energy;
    [SerializeField] private TextMeshProUGUI internet;
    [SerializeField] private TextMeshProUGUI total;
    [SerializeField] private TextMeshProUGUI cash;

    private float[] debit;

    private void Start()
    {
        int baseValue = GameController.getBaseValue();
        debit = new float[7];
        debit[0] = baseValue;
        debit[1] = baseValue;
        debit[2] = baseValue / 3;
        debit[3] = baseValue / 10;
        debit[4] = baseValue / 1.5f;
        debit[5] = baseValue / 8;
        debit[6] = baseValue / 3;

        rent.text = "$ " + (baseValue).ToString("F2");
        college.text = "$ " + (baseValue).ToString("F2");
        transport.text = "$ " + (baseValue / 3).ToString("F2");
        netflix.text = "$ " + (baseValue / 10).ToString("F2");
        food.text = "$ " + (baseValue / 1.5).ToString("F2");
        energy.text = "$ " + (baseValue / 8).ToString("F2");
        internet.text = "$ " + (baseValue / 3).ToString("F2");

        Debug.Log("Times saved: " + (int)GameController.results[Status.Money]);
        Debug.Log("final save bonus: " + GameController.getSaveMultiplier() * (int)GameController.results[Status.Money]);

        float finalCash = GameController.getInitialMoney() + (GameController.getInitialMoney() * GameController.getSaveMultiplier() * (int) GameController.results[Status.Money]);

        cash.text = "$ " + (finalCash).ToString("F2");
        total.text = "$ " + (debit.Sum()).ToString("F2");

        Invoke("goToMenu", 3);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

public enum DebitType
{
    Rent,
    College,
    Transport,
    Netflix,
    Food,
    Energy,
    Internet
}