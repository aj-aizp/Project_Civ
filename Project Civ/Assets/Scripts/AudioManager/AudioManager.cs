using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Responsible for background Music Player. Attached to AudioManager empty object in scene
*/
public class AudioManager : MonoBehaviour
{
    [Header(".............Audio Source............")]
    [SerializeField]
    AudioSource musicSource;

    public AudioClip backgroundMusic;

    //Start at the beggining of the scene
    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
