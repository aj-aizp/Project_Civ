using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionSol : MonoBehaviour
{
   private GameObject selectedSprite;
   private UnitController movePosition;

   private void Awake() {
    movePosition = GetComponent<UnitController>();
    selectedSprite = transform.Find("SelectedSprite").gameObject;
    SetSelectedVisible(false);
   }

   public void SetSelectedVisible(bool visible) {
    selectedSprite.SetActive(visible);
   }

   public void MoveOrder(Vector3 position) {
    movePosition.setMovePosition(position); 
   }
}
