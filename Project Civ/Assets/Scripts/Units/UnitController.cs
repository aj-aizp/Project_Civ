using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Transactions;
using UnityEditor.Build.Content;
using UnityEngine;

public class UnitController : MonoBehaviour
{
  
    private Animator animator;  
    private Vector3 movePosition;
    public float speed = 1f;
    private bool moving;

    private void Start() {
        animator = transform.GetComponent<Animator>();
        
    }

    public void setMovePosition (Vector3 movePosition) {
        this.movePosition = movePosition; 
    }

    private void Awake() {
        movePosition = transform.position;
    }


//Move to Mouse Click Position (World Space)
 void Update() {

    transform.position = Vector3.MoveTowards(transform.position,movePosition,speed+Time.deltaTime);  //Smooth movement 
    

    moving = transform.position != movePosition;
    

    if (moving) {
        animator.SetBool("isMoving",true);
        animator.SetBool("isShooting",false);
    }

    else{
        animator.SetBool("isMoving",false);
    }
        
    }





}
