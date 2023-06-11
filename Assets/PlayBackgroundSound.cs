using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundSound : MonoBehaviour
{
    public AudioClip backgroundMusicClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
