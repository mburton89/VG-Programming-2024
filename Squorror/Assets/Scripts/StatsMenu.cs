using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;
using System.Security;
using System;

public class StatsMenu : MonoBehaviour
{
    public GameManager GameManager;
    public string playerWeight;
    public string baseWeight;
    public string finalWeight;
    

    public TMP_Text playerWeightCount;
    public TMP_Text baseWeightCount;
    public TMP_Text finalWeightCount;

    private void Update()
    {
        playerWeight = GameManager.totalPlayerWeight.ToString();
        baseWeight = GameManager.totalBaseWeight.ToString();
        finalWeight = GameManager.totalWeight.ToString();
        playerWeightCount.SetText(playerWeight);
        baseWeightCount.SetText(baseWeight);
        finalWeightCount.SetText(finalWeight);
    }
}
