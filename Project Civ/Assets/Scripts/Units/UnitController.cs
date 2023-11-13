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
    private int soldierType; 
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
        soldierType = transform.GetComponent<UnionSol>().getSoldierType(); 
    }


//Move to Mouse Click Position (World Space)
 void Update() {

    transform.position = Vector3.MoveTowards(transform.position,movePosition,speed+Time.deltaTime);  //Smooth movement 
    

 //FIX OR REPLACE THIS CODE 
    moving = transform.position != movePosition;
    

     if (moving) {
        switch(soldierType) {
            case 1:
             animator.Play("Union_Move", 0,1f);
            break; 
            case 2:
            animator.Play("Walking_Rifle",0,1f);
            break;
        }
     }
     else{
         moving = false; 

         switch(soldierType){
            case 1:
             animator.Play("Union_Idle", 0,1f);
            break; 
            case 2:
             animator.Play("Idle",0,1f);
            break; 

         }
     }

    }


   

}
