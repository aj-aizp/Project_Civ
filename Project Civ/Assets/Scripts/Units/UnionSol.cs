using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnionSol : MonoBehaviour
{
   
    private GameObject selectedSprite;
    private UnitController movePosition;
    private bool dead;

    private int soldierType; 


private void Awake(){
   dead = false; 
   movePosition = GetComponent<UnitController>();
   selectedSprite = transform.Find("SelectedSprite").gameObject;
   SetSelectedVisible(false);
  
}

public void disableMove() {
   movePosition.enabled = false; 
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

   public void setDeathState (bool dead) {
      this.dead = dead; 
   }

   public void setSoldierType(int soldierType) {
      this.soldierType = soldierType; 
   }

   public int getSoldierType(){
      return soldierType; 
   }

}
