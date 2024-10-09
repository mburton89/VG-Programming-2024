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

    public Image cursor;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateWeightBarUI(float currentWeight, float maxWeight)
    {
        weightBar.fillAmount = currentWeight / maxWeight;

        if (currentWeight / maxWeight > 0.8f)
        {
            weightBar.color = Color.red;
        }
        else
        { 
            weightBar.color = Color.white;
        }
    }

    public void UpdateBaseWeightNumber(float baseWeight)
    {
        baseWeightNumber.SetText(baseWeight.ToString("0.00"));
    }

    public void UpdatePlayerWeightNumber(float playerWeight)
    {
        playerWeightNumber.SetText(playerWeight.ToString("0.00"));
    }

    public void UpdateCursorColor(Color newColor)
    {
        cursor.color = newColor;

/*        if (newColor == Color.red)
        {
            cursor.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            cursor.transform.localScale = Vector3.one;
        }*/
    }
}
