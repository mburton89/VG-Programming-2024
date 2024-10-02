using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRespawnOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            if (CollectibleSpawner.Instance == null) return;
            CollectibleSpawner.Instance.cubeCount--;
            Debug.Log(CollectibleSpawner.Instance.cubeCount);
            Destroy(gameObject);
            Debug.Log("TOUCHING");
            CollectibleSpawner.Instance.SpawnOneCollectible();
            
        }
        
    }
}
