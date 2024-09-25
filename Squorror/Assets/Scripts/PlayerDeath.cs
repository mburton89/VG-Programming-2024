using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : PlayerMechanics
{
    bool isDead = false;
    public float currentHealth;

    void Update()
    {
        HandleDeath();
        HandleUI();
    }

    public void HandleDeath()
    {
        if (currentHealth  <= 0)
        {
            isDead = true;
        }
    }
    public void HandleUI()
    {
        if (isDead == false)
        {
            GameObject.Find("UI").SetActive(false);
        }

        else
        {
            GameObject.Find("UI").SetActive(true);
        }
    }
}
