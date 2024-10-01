using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public TextMeshProUGUI baseWeightNumber;
    public TextMeshProUGUI playerWeightNumber;

    public Image weightBar;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateWeightBarUI(float currentWeight, float maxWeight)
    {
        weightBar.fillAmount = currentWeight / maxWeight;
    }

    public void UpdateBaseWeightNumber(int baseWeight)
    {
        baseWeightNumber.SetText(baseWeight.ToString());
    }

    public void UpdatePlayerWeightNumber(int baseWeight)
    {
        playerWeightNumber.SetText(baseWeight.ToString());
    }
}
