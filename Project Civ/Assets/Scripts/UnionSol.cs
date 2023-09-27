using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionSol : MonoBehaviour
{
   private GameObject selectedSprite;
   private UnitController movePosition;
   private Animator unionAnim; 
   private bool dead;
   private int health; 

   private void Awake() {
    health = 100;
    dead = false; 
    movePosition = GetComponent<UnitController>();
    unionAnim = GetComponent<Animator>();
    selectedSprite = transform.Find("SelectedSprite").gameObject;
    SetSelectedVisible(false);
   }

   public void SetSelectedVisible(bool visible) {
    selectedSprite.SetActive(visible);
   }

   public void MoveOrder(Vector3 position) {
    movePosition.setMovePosition(position); 
   }

   public bool getDeathState(){
      return dead;
   }
   public void Death(){
        dead = true;
        unionAnim.enabled = false; 
        enabled = false;
        transform.rotation = Quaternion.Euler(0,0,90);
        Destroy(gameObject,5f);
   }

   public void Damage(int damage){
      this.health -=damage;
   }

   private void Update() {

      if(health <=0){
         Death();
      }
      
   }

}
