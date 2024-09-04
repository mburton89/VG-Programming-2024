using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    private Ball activeBall;
    public Paddle activePaddle;
    public float distanceBuffer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBall == null)
        {
            LookForBall();
        }
        else
        {
            if (BallIsApproaching())
            { 
                FollowBall();
            }
        }
    }

    void LookForBall()
    {
        activeBall = FindFirstObjectByType<Ball>();
    }

    void FollowBall()
    {
        if (activeBall.transform.position.y > activePaddle.transform.position.y + distanceBuffer)
        {
            activePaddle.MoveUp();
        }
        else if (activeBall.transform.position.y < activePaddle.transform.position.y - distanceBuffer)
        {
            activePaddle.MoveDown();
        }
    }

    bool BallIsApproaching()
    {
        if (activePaddle.transform.position.x > 0)
        {
            if (activeBall.direction.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else //Paddle is on the left
        {
            if (activeBall.direction.x < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
