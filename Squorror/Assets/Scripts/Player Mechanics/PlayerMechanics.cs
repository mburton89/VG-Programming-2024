using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public int itemsCollected;
    bool isDead;
    public float maxHealth;
    public float currentHealth;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveDirection = Camera.main.transform.TransformDirection(movement);
        moveDirection.y = 0f;

        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

}
