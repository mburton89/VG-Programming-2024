using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance;
    public List<GameObject> levelLayouts;
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLevel()
    {
        Debug.Log("Start Level Spawn");
        int rand = Random.Range(0, levelLayouts.Count - 1);
        GameObject spawnedLevel = levelLayouts[2];
        spawnedLevel.SetActive(true);
        Debug.Log("Spawned Level " + rand);


    }
}
