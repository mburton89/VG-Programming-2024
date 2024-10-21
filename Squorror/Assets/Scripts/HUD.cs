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

    public GameObject pressEToCollect;
    public GameObject pressEToDropOff;
    public GameObject tooHeavy;


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

    public void ShowPressEToCollect()
    {
        pressEToCollect.SetActive(true);
    }

    public void HidePressEToCollect()
    {
        pressEToCollect.SetActive(false);
    }

    public void ShowTooHeavy()
    {
        if (!tooHeavy.activeInHierarchy)
        { 
            StartCoroutine(ShowTooHeavyCo());
        }
    }

    private IEnumerator ShowTooHeavyCo()
    {
        tooHeavy.SetActive(true);
        yield return new WaitForSeconds(2);
        tooHeavy.SetActive(false);
    }

    public void ShowPressEToDropOff()
    {
        pressEToDropOff.SetActive(true);
    }

    public void HidePressEToDropOff()
    {
        pressEToDropOff.SetActive(false);
    }
}
