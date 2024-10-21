using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectibleWeight;
    public float minCollectibleSize;
    public float maxCollectibleSize;

    public Material lightMaterial;
    public Material midMaterial;
    public Material heavyMaterial;

    // Start is called before the first frame update
    void Start()
    {
        float randSize = Random.Range(minCollectibleSize, maxCollectibleSize);
        Vector3 newSize = new Vector3(randSize, randSize, randSize);
        transform.localScale = newSize;
        collectibleWeight = randSize * randSize;
        AssignMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        //GetCollected();
    }

   // private void OnCollisionEnter(Collision collision)
   // {
   //   GetCollected(); //Make it so player collision only???
   // }
 
    public void GetCollected()
    {
        GameManager.Instance.AddWeightToPlayer(collectibleWeight);
        //Debug.Log();
        //Destroy(gameObject);
    }

    public void AssignMaterial()
    {
        if (collectibleWeight <= 0.33f * maxCollectibleSize)
        {
            GetComponent<Renderer>().material = lightMaterial;
        }
        else if (collectibleWeight <= 0.66f * maxCollectibleSize)
        {
            GetComponent<Renderer>().material = midMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = heavyMaterial;
        }
    }

    public void SlowDownPlayer()
    {

    }
}
