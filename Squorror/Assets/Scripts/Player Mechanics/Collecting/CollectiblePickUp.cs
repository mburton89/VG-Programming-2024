using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickUp : MonoBehaviour
{
    public float pickUpRange = 2.0f; // Distance within which the player can pick up the object
    public float dropOffRange = 2.0f; // Distance within which the player can drop off items
    public Transform playerCamera; // Reference to the player's camera
    public LayerMask pickUpLayer; // Layer mask to detect pickable objects
    public LayerMask dropOffLayer; // Layer mask for drop-off points
    private int currentItemCount = 0; // Current number of collected items
    public int CurrentItemCount => currentItemCount;

    private List<GameObject> collectedItems = new List<GameObject>(); // List to hold collected items
    private GameObject dropOffPoint;
    private GameObject objectInRange;
    private GameObject collectible;

    // Maximum number of items the player can hold
    public int maxItems = 5;

    // Current number of items the player is holding
    private int currentItems = 0;

    void Start()
    {
        // Initialize the inventory
        UpdateInventoryUI();
    }

    void Update()
    {
        CheckForObjectInRange();

        // Check if the player presses the "E" key and there is an object to pick up
        if (objectInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }

        CheckForDropOffPoint();
    }

    // Method to add an item
    public bool AddItem()
    {
        if (currentItems < maxItems)
        {
            currentItems++;
            UpdateInventoryUI();
            return true; // Successfully added item
        }
        else
        {
            Debug.Log("Inventory is full!");
            return false; // Inventory full
        }
    }

    // Method to remove an item
    public bool RemoveItem()
    {
        if (currentItems > 0)
        {
            Debug.Log("Item removed");
            currentItems--;
            UpdateInventoryUI();
            return true; // Successfully removed item
        }
        else
        {
            Debug.Log("No items to remove!");
            return false; // No items to remove
        }
    }

    // Method to check the current number of items
    public int GetCurrentItemCount()
    {
        return currentItems;
    }

    // Method to get the maximum number of items
    public int GetMaxItemCount()
    {
        return maxItems;
    }

    // Display or update the inventory UI
    private void UpdateInventoryUI()
    {
        // Placeholder for updating any UI elements displaying inventory counts
        Debug.Log($"Inventory: {currentItems}/{maxItems} items");
    }

    // Method to check if there is an object within range
    void CheckForObjectInRange()
    {
        RaycastHit hit;

        // Cast a ray from the camera's position in the direction the camera is facing
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickUpRange, pickUpLayer))
        {
            // If the ray hits an object within the pick-up layer, set it as the object in range
            objectInRange = hit.collider.gameObject;
            Debug.Log($"Object in range: {objectInRange.name}");
        }
        else
        {
            objectInRange = null;
        }
    }

    // Method to pick up the item
    void PickUpItem()
    {
        if (AddItem())
        {
            Debug.Log($"Picked up: {objectInRange.name}");
            Destroy(objectInRange);
            objectInRange = null;
        }
        else
        {
            Debug.Log("Unable to pick up item: Inventory full");
        }
    }

    // Check for a drop-off point within range
    void CheckForDropOffPoint()
    {
        RaycastHit hit;

        // Cast a ray from the camera's position in the direction the camera is facing
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, dropOffRange, dropOffLayer))
        {
            // If the ray hits an object within the drop-off layer, set it as the drop-off point
            dropOffPoint = hit.collider.gameObject;
        }
        else
        {
            dropOffPoint = null;
        }
    }

    // Method to drop off all collected items
    public void DropAllItems()
    {
        if (currentItems > 0)
        {
            Debug.Log($"Dropped off all items: {currentItems}");
            currentItems = 0;
            UpdateInventoryUI();
        }
        else
        {
            Debug.Log("No items to drop off!");
        }
    }

    // Collision detection to drop off items
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "DropOff" tag
        if (collision.gameObject.CompareTag("DropOff"))
        {
            Debug.Log($"Collided with drop-off object: {collision.gameObject.name}");
            DropAllItems();
        }
    }
}
