using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header(".............Audio Source............")]
   [SerializeField] AudioSource musicSource; 



   public AudioClip backgroundMusic; 

   private void Start() {
    musicSource.clip = backgroundMusic; 
    musicSource.Play(); 
   }

}
