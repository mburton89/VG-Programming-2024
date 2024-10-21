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

    CollectiblePickUp player;

    private void Start()
    {
        player = FindFirstObjectByType<CollectiblePickUp>();
    }

    private void Update()
    {
        playerWeight = player.currentWeight.ToString("0.00");
        baseWeight = GameManager.totalBaseWeight.ToString("0.00");

        float totalWeight = player.currentWeight + GameManager.totalBaseWeight;
        finalWeight = totalWeight.ToString("0.00");
        playerWeightCount.SetText(playerWeight);
        baseWeightCount.SetText(baseWeight);
        finalWeightCount.SetText(finalWeight);
    }
}
