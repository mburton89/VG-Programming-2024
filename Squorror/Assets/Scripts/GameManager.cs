using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float totalPlayerWeight;
    public float totalBaseWeight;
    public float weightToAdd;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPlayerWeight = 0;  
    }

    public void AddWeightToPlayer(float weightToAdd)
    {
        totalPlayerWeight += weightToAdd;
    }

    public void AddWeightToBase()
    {
       // totalPlayerWeight = 0;
        totalBaseWeight += totalPlayerWeight;
       
    }
}
