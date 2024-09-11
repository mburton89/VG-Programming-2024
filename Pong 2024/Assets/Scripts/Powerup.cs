using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlayPowerSound();
        GetCollected();
        Destroy(gameObject);
    }

    public abstract void GetCollected();
}
