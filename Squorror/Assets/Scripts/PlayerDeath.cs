using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public PlayerMechanics playerMechanics;
    public GameObject StatsMenuContainer;
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
            StatsMenuContainer.SetActive(false);
        }

        else
        {
            StatsMenuContainer.SetActive(true);
        }
    }
}
