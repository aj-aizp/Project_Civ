using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.Build.Content;
using UnityEngine;

public class unitController : MonoBehaviour
{
  
    private Animator animator;  
    public float speed = 1f;
    private Vector3 worldPosition;

   // private bool collision;

    private bool moving;

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }


// private void OnCollisionEnter2D(Collision2D col) {
    
// collision = true;
       
// }


//Move to Mouse Click Position (World Space)
 void Update() {

    if (Input.GetMouseButtonDown(0)){

    worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    worldPosition.z = 0f;
    }

  //  if (collision == false) {
    transform.position = Vector3.MoveTowards(transform.position,worldPosition,speed+Time.deltaTime);  //Smooth movement 
    //}

    // else if (collision ==true) {
    // transform.position = Vector3.MoveTowards(transform.position,-worldPosition/10,speed+Time.deltaTime);  //Smooth movement 
    // }

    moving = transform.position !=worldPosition;
    

    if (moving) {
        animator.SetBool("isMoving",true);
        animator.SetBool("isShooting",false);
    }

    else{
        animator.SetBool("isMoving",false);
    }

    if(Input.GetMouseButton(1) && !moving ){
        animator.SetBool("isShooting",true);
    }

    else{
        animator.SetBool("isShooting", false);
    }

   // collision = false;
        
    }





}
