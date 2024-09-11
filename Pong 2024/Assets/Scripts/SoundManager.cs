using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource blipSound;
    public AudioSource powerSound;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBlipSound()
    {
        blipSound.pitch = Random.Range(0.9f, 1.1f);
        blipSound.Play();
    }
    public void PlayPowerSound()
    {
        powerSound.pitch = Random.Range(0.9f, 1.1f);
        powerSound.Play();
    }
}
