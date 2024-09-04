using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;

    public Vector3 spawnDirection;
    public GameObject ballPrefab;

    public float secondsToWaitBeforeSpawn;

    public float yAddition;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnBall();
        //}
    }

    public void SpawnBall()
    {
        StartCoroutine(DelaySpawnBall());
    }

    private IEnumerator DelaySpawnBall()
    {
        Debug.Log("Start Ball Spawn");
        yield return new WaitForSeconds(secondsToWaitBeforeSpawn);
        Debug.Log("Spawn Ball");
        GameObject newBall = Instantiate(ballPrefab);

        float randY = 0;

        while (randY < 0.2f && randY > -0.2f)
        {
            randY = Random.Range(-0.5f, 0.5f);
        }

        spawnDirection = new Vector3(spawnDirection.x, spawnDirection.y + randY);

        newBall.GetComponent<Ball>().direction = spawnDirection;
    }
}
