using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public PlayerMechanics playerMechanics;

    bool isDead = false;

    void Update()
    {
        HandleDeath();
        HandleUI();
    }

    public void HandleDeath()
    {
        if (playerMechanics.currentHealth  <= 0)
        {
            isDead = true;
            playerMechanics.enabled = false;
            GetComponent<FirstPersonCamera>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void HandleUI()
    {
        if (isDead == false)
        {
            GameObject.Find("Canvas").SetActive(false);
        }

        else
        {
            GameObject.Find("Canvas").SetActive(true);
        }
    }
}
