using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource blipSound;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBlipSound()
    {
        blipSound.pitch = Random.Range(0.9f, 1.1f);
        blipSound.Play();
    }
}
