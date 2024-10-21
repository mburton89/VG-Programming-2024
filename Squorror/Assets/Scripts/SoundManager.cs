using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource collect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(AudioClip clip, Vector3 position, float volume)
    {
        GameObject soundObject = new GameObject("SoundEffect");
        soundObject.transform.position = position;
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = false;
        audioSource.Play();
        audioSource.volume = volume;
        Destroy(soundObject,clip.length);
    }

    public void PlayCollectSound()
    {
        collect.Play();
    }
}
