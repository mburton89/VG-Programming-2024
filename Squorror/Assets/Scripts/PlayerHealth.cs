using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthCollision : MonoBehaviour
{
    public PlayerMechanics playerMechanics;
    public string colliderTag1 = "Player"; // Tag for the first collider
    public string colliderTag2 = "Enemy";  // Tag for the second collider

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has one of the specified tags
        if (collision.gameObject.CompareTag(colliderTag1) || collision.gameObject.CompareTag(colliderTag2))
        {
            // Check if the other collider has the other specified tag
            if ((collision.gameObject.CompareTag(colliderTag1) && gameObject.CompareTag(colliderTag2)) ||
                (collision.gameObject.CompareTag(colliderTag2) && gameObject.CompareTag(colliderTag1)))
            {
                // Modify currentHealth on collision
                ChangeHealth(-1); // Change this value as needed
            }
        }
    }

    private void ChangeHealth(int amount)
    {
        playerMechanics.currentHealth += amount;
        Debug.Log("Current Health: " + playerMechanics.currentHealth);

        // Check if health is zero or below
        if (playerMechanics.currentHealth <= 0)
        {
            Debug.Log("Player has died.");
            // You can add more logic here for when the player dies
        }
    }
}