using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectibleWeight;
    public float minCollectibleSize;
    public float maxCollectibleSize;


    // Start is called before the first frame update
    void Start()
    {
        float randSize = Random.Range(minCollectibleSize, maxCollectibleSize);
        Vector3 newSize = new Vector3(randSize, randSize, randSize);
        transform.localScale = newSize;
        collectibleWeight = randSize * randSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            GetCollected();
        }
    }

   // private void OnCollisionEnter(Collision collision)
   // {
   //   GetCollected(); //Make it so player collision only???
   // }
 
    public void GetCollected()
    {
        GameManager.Instance.AddWeightToPlayer(collectibleWeight);
        Destroy(gameObject);
    }

    public void SlowDownPlayer()
    {

    }
}
