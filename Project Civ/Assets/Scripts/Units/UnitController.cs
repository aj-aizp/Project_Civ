using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Transactions;
using UnityEditor.Build.Content;
using UnityEngine;

/*
Updates the movement postion of each unit. Also plays movement animation when needed
*/
public class UnitController : MonoBehaviour
{
    private Animator animator;
    private Vector3 movePosition;
    private int soldierType;
    public float speed = 1f;
    private bool moving;

    public void setMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }

    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
        movePosition = transform.position;
    }

    //Move to Mouse Click Position (World Space)
    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            movePosition,
            speed + Time.deltaTime
        ); //Smooth movement

        moving = transform.position != movePosition;
        soldierType = transform.GetComponent<UnionSol>().getSoldierType();
        
        //Switch statement improvement over a bunch of if/else statements when soldier status is known before hand
        if (moving)
        {
            switch (soldierType)
            {
                case 1:
                    animator.Play("Union_Move", 0, 1f);
                    break;

                case 2:
                    animator.SetBool("isMoving", true);
                    break;

                case 3:
                    animator.SetBool("Machine_Move", true);
                    break;
            }
        }
        else
        {
            moving = false;

            switch (soldierType)
            {
                case 1:
                    animator.Play("Union_Idle", 0, 1f);
                    break;
                case 2:
                    animator.SetBool("isMoving", false);
                    break;

                case 3:
                    animator.SetBool("Machine_Move", false);
                    break;
            }
        }
    }
}
