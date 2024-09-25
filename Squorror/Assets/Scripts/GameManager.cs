using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public float totalPlayerWeight;
    public float totalBaseWeight;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    AddWeightToBase();
        //}
    }

    public void AddWeightToPlayer(float weightToAdd)
    {
        totalPlayerWeight += weightToAdd;
    }

    public void AddWeightToBase()
    {
        totalBaseWeight += totalPlayerWeight;
        totalPlayerWeight = 0;
    }
}
