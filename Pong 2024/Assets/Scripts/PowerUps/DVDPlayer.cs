using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDPlayer : MonoBehaviour
{
   

    public float movementSpeed;
    public Vector3 direction;
    public int xHitDirection;
    public float maxYPosition; //WALLS

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();
    }

    public void GetHit(Vector3 hitDirection)
    {
        direction = hitDirection;
        //SoundManager.instance.PlayBlipSound();
    }

    void Move()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    void CheckBoundaries()
    {
        if (transform.position.y > maxYPosition && direction.y > 0)
        {
            direction = new Vector3(direction.x, -direction.y, 0);
        }
        else if (transform.position.y < -maxYPosition && direction.y < 0)
        {
            direction = new Vector3(direction.x, -direction.y, 0);
        }
    }

  
}
