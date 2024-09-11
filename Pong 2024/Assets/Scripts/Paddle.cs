using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxYPosition;
    public float verticalMovementSpeed;
    public int xHitDirection;

    public KeyCode upKey;
    public KeyCode downKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        { 
            MoveUp();
        }
        else if (Input.GetKey(downKey))
        {
            MoveDown();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float yHitDirection = collision.transform.position.y - transform.position.y;
            Vector3 newHitDirection = new Vector3(xHitDirection, yHitDirection, 0);
            collision.gameObject.GetComponent<Ball>().GetHit(newHitDirection);
        }
    }

    public void MoveUp()
    {
        if (transform.position.y < maxYPosition)
        { 
            transform.position += Vector3.up * verticalMovementSpeed * Time.deltaTime;
        }
    }

    public void MoveDown()
    {
        if (transform.position.y > -maxYPosition)
        { 
            transform.position += Vector3.down * verticalMovementSpeed * Time.deltaTime;
        }
    }

    void HitBall()
    { 
    
    }
}
