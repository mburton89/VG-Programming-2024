using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectiblePickUp : MonoBehaviour
{
    public float pickUpRange = 2.0f; // Distance within which the player can pick up the object
    public float dropOffRange = 2.0f; // Distance within which the player can drop off items
    private float speed;
    public Transform playerCamera; // Reference to the player's camera
    public LayerMask pickUpLayer; // Layer mask to detect pickable objects
    public LayerMask dropOffLayer;
    public LayerMask useless;

    public GameObject collectiblePrefab; // Prefab of the collectible to instantiate
    public Transform dropOffCube; // Reference to the drop-off point in the scene
    public float spawnOffset = 1.0f; // Offset to avoid overlap when instantiating collectibles

    [SerializeField] private int currentItems = 0; // Current number of collected items
    private GameObject objectInRange; // Object currently in pick-up range
    private GameObject dropOffPoint; // The drop-off object within range
    private List<GameObject> collectedItems = new List<GameObject>(); // List to hold collected items

    [SerializeField] PlayerMechanics playerMechanics;

    public int maxItems = 5; // Maximum number of items the player can hold

    void Start()
    {
        UpdateInventoryUI(); // Initialize the inventory UI
        playerMechanics = GetComponent<PlayerMechanics>();
        
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

    // Method to check if there is an object within range
    void CheckForObjectInRange()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickUpRange, pickUpLayer))
        {
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
        if (currentItems < maxItems)
        {
            collectedItems.Add(objectInRange); // Add the item to the list
            Destroy(objectInRange); // Destroy the item in the scene
            currentItems++;
            playerMechanics.speed -=2;
            UpdateInventoryUI();
            Debug.Log($"Picked up: {objectInRange.name}");
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    // Display or update the inventory UI
    private void UpdateInventoryUI()
    {
        Debug.Log($"Inventory: {currentItems}/{maxItems} items");
    }

    // Check for a drop-off point within range
    void CheckForDropOffPoint()
    {
        //Debug.Log("First Line CheckForDropOffPoint");
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, dropOffRange, dropOffLayer) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Second Line CheckForDropOffPoint");
            dropOffPoint = hit.collider.gameObject;
            DropAndInstantiateItems();
        }
        else
        {
            //Debug.Log("Third Line CheckForDropOffPoint");
            dropOffPoint = null;
        }
    }

    // Collision detection to drop off items
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DropOff") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"Collided with drop-off object: {collision.gameObject.name}");
            DropAndInstantiateItems();
        }
    }*/

    // Method to drop off and instantiate all collected items
    public void DropAndInstantiateItems()
    {
        if (currentItems > 0)
        {
            for (int i = 0; i < currentItems; i++)
            {
                InstantiateCollectible(i);
            }
            collectedItems.Clear(); // Clear the list of collected items
            currentItems = 0; // Reset item count
            UpdateInventoryUI();
            Debug.Log("All items dropped off and instantiated.");
        }
        else
        {
            Debug.Log("No items to drop off!");
        }
    }

    // Method to instantiate a single collectible at the drop-off point
    private void InstantiateCollectible(int index)
    {
        if (collectiblePrefab != null)
        {
            // Calculate the spawn position with a slight offset to prevent overlap
            Vector3 spawnPosition = dropOffCube.position + new Vector3(index * spawnOffset, 1.524f, 0);
            GameObject collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
            collectible.name = $"Collectible_{index + 1}";
            Rigidbody rb = collectible.AddComponent<Rigidbody>();
            if (rb != null)
            { 
                rb.mass = 1f;
            }
            //transform.gameObject.layer = useless;
            Debug.Log($"Instantiated {collectible.name} at position {spawnPosition}");
        }
        else
        {
            Debug.LogError("Collectible prefab is not assigned!");
        }
    }
}
