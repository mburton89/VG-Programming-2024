using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation amount
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around the Y axis
        transform.Rotate(0, rotationAmount, 0);
    }
}