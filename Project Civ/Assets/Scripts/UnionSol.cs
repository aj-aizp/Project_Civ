using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionSol : MonoBehaviour
{
   private GameObject selectedSprite;

   private void Awake() {
    selectedSprite = transform.Find("SelectedSprite").gameObject;
    SetSelectedVisible(false);
   }

   public void SetSelectedVisible(bool visible) {
    selectedSprite.SetActive(visible);
   }
}
