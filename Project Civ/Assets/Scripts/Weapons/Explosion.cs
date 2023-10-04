using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Principal;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator; 
    private void Awake() {
        animator = GetComponent<Animator>() ;
        animator.Play("Explosion");
        Destroy(gameObject,4f);
        
    }

    private void Update() {
    }

  
}
