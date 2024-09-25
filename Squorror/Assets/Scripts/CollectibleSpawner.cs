using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{

    public static CollectibleSpawner Instance;
    public GameObject collectible;
    public int cubeCount = 0;
    public int spawnRange;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnOneCollectible();
        }
    }

   public void SpawnOneCollectible()
    {
        int randX = Random.Range(-spawnRange, spawnRange);
        int randZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(randX, 5f, randZ);
        Instantiate(collectible, spawnPosition, Quaternion.identity);
        cubeCount++;
        Debug.Log(cubeCount.ToString());
    }

    void InitialSpawn()
    {
        for (int i = 0; i < 10; i++)
        {
            int randX = Random.Range(-spawnRange, spawnRange);
            int randZ = Random.Range(-spawnRange, spawnRange);
            Vector3 spawnPosition = new Vector3(randX, 5f, randZ);
            Instantiate(collectible, spawnPosition, Quaternion.identity);
            cubeCount++;
            Debug.Log(cubeCount.ToString());
        }
    }
}
