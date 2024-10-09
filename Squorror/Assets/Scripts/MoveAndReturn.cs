using UnityEngine;

public class MoveAndReturn : MonoBehaviour
{
    public float distance = 5f; // Distance to move
    public float speed = 2f; // Movement speed

    private Vector3 startPosition; // Starting position
    private Vector3 targetPosition; // Target position
    private bool movingToTarget = true; // Direction flag

    public bool shouldFlip;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * distance;
    }

    void Update()
    {
        // Determine the target position based on the movement direction
        Vector3 currentTarget = movingToTarget ? targetPosition : startPosition;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Check if the object has reached the target
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            // Switch direction
            movingToTarget = !movingToTarget;

            // Rotate 180 degrees
            if (shouldFlip)
            { 
                transform.Rotate(0, 180f, 0);
            }
        }
    }
}