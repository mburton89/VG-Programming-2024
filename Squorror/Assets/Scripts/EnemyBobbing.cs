using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBobbing : MonoBehaviour
{
    //Bobbing Speed
    public float bobbingSpeed = 1f;
    private float bobbingMultiplier = 0.0025f;
    private float bobbingActualSpeed;

    //Bobbing Positions
    Vector3 offset = new Vector3(0, 1.5f, 0);
    Vector3 startingPos;
    Vector3 endingPos;
    Vector3 bobbingDestination;

    void Start()
    {
        offset = Vector3.up;
        startingPos = transform.position;
        endingPos = transform.position + offset;
    }

    void Update()
    {
        Bobbing();
    }

    public void Bobbing()
    {
        bobbingActualSpeed = bobbingSpeed * bobbingMultiplier;

        if (transform.position.y == startingPos.y)
        {
            bobbingDestination = new Vector3(transform.position.x, endingPos.y, transform.position.z);
        }
        if (transform.position.y == endingPos.y)
        {
            bobbingDestination = new Vector3(transform.position.x, startingPos.y, transform.position.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, bobbingDestination, bobbingActualSpeed);
    }
}
