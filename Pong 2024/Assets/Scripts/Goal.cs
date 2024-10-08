using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftPlayer;

    public GameObject splodePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            HandleBallCollision();
            Instantiate(splodePrefab, collision.gameObject.transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }

    void HandleBallCollision()
    {
        if (isLeftPlayer)
        {
            BallSpawner.Instance.spawnDirection = Vector3.left;
        }
        else
        {
            BallSpawner.Instance.spawnDirection = Vector3.right;
        }

        ScoreManager.Instance.GivePoint(isLeftPlayer);
    }
}
