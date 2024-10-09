    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class VoidDeath : MonoBehaviour
{
   
    public float moveSpeed = 10f; // Speed of movement
    public float jumpscareTime;
    public NavMeshAgent ai;
    public Transform player;
    public float viewAngleThreshold = 65; // Angle threshold to consider the object 'observed'
    Vector3 dest;
    public Camera playerCam, jumpscareCam;
    public float catchDistance;
    public AudioClip jumpscareSound;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        playerCam = GameObject.Find("Player").GetComponentInChildren<Camera>();

    }
    void Update()
    {
        // Move the object if it's not being observed
        CheckPlayerHeight(); // Implement your movement logic here
    }

    private void CheckPlayerHeight()
    {

        //If the distance between the player and the AI is less than or equal to the catchDistance,
        //if (OnCollisionEnter())//distance <= catchDistance && (player.gameObject.activeSelf == true))
        {
            player.gameObject.SetActive(false); //The player object will be set false
            jumpscareCam.gameObject.SetActive(true); //The jumpscare camera will be set true
            SoundManager.Instance.Play(jumpscareSound, transform.position, .5f);
        }
    }
}
