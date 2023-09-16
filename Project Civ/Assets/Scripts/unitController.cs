using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class unitController : MonoBehaviour
{
  
    private Animator animator;  
    public float speed = 1f;
    private Vector3 worldPosition;
    private Vector3 displacement; 

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

//Move to Mouse Click Position (World Space)
 void Update() {

    if (Input.GetMouseButtonDown(0)){

    worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    worldPosition.z = 0f;
    }

    // displacement = worldPosition - transform.position;  //Distance between MouseClick and Unit
    // displacement = displacement.normalized; 

    // transform.position += displacement * speed * Time.deltaTime;

    transform.position = Vector3.MoveTowards(transform.position,worldPosition,speed+Time.deltaTime);  //Smooth movement

    if (transform.position != worldPosition) {
        animator.SetBool("isMoving",true);
    }

    else{
        animator.SetBool("isMoving",false);
    }
        
    }

}
