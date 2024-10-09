using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Monster : MonoBehaviour
{
   
    public float moveSpeed = 10f; // Speed of movement
    private bool isMoving = true; // Whether the object should be moving
    public float jumpscareTime;
    public NavMeshAgent ai;
    public Transform player;
    public float viewAngleThreshold = 65; // Angle threshold to consider the object 'observed'
    Vector3 dest;
    public Camera playerCam, jumpscareCam;
    public float catchDistance;
    public AudioClip jumpscareSound;
    public Material activeMaterial;
    public Material monsterFace1;
    public Material monsterFace2;

    private void Start()
    {
        int faceNumber = UnityEngine.Random.Range(1, 3);
        if(faceNumber == 1)
            activeMaterial = monsterFace1;
        else
            activeMaterial = monsterFace2;
        Debug.Log(faceNumber);
        gameObject.GetComponent<MeshRenderer>().material = activeMaterial;
        player = GameObject.Find("Player").transform;
        playerCam = GameObject.Find("Player").GetComponentInChildren<Camera>();
    }
    void Update()
    {
        // Check if the object is being observed
        if (IsLookedAt() && IsObserved())
        {
            isMoving = false;
            ai.speed = 0;
        }
        else
        {
            isMoving = true;
        }

        // Move the object if it's not being observed
        if (isMoving)
        {
            MoveTowardsPlayer(); // Implement your movement logic here
        }
    }

    private bool IsLookedAt()
    {
        // Calculate the direction to the object
        Vector3 directionToObject = (transform.position - playerCam.transform.position).normalized;
        // Get the camera's forward direction
        Vector3 cameraForward = playerCam.transform.forward;

        // Calculate the angle between the camera's forward direction and the direction to the object
        float angle = Vector3.Angle(cameraForward, directionToObject);

        // Check if the angle is within the threshold
        return angle < viewAngleThreshold;
    }

    private bool IsObserved()
    {
        Ray ray = new Ray(playerCam.transform.position, transform.position - playerCam.transform.position);
        RaycastHit hit;

        // Check if the ray hits the object and that there are no other objects in between
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider == GetComponent<Collider>();
        }

        return false;
    }

    private void MoveTowardsPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        ai.speed = moveSpeed; //The AI's speed will equal to the value of aiSpeed
        dest = player.position; //dest will equal to the player's position
        ai.destination = dest; //The AI's destination will equal to dest

        //If the distance between the player and the AI is less than or equal to the catchDistance,
        if (distance <= catchDistance && (player.gameObject.activeSelf == true))
        {
            player.gameObject.GetComponent<PlayerMechanics>().currentHealth = 0;
            //player.gameObject.SetActive(false); //The player object will be set false
            jumpscareCam.gameObject.SetActive(true); //The jumpscare camera will be set true
            SoundManager.Instance.Play(jumpscareSound, transform.position, .5f);
        }
    }
}
