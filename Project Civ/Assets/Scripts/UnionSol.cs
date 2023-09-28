using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionSol : MonoBehaviour
{
   private GameObject selectedSprite;
   private UnitController movePosition;
   private Animator unionAnim; 
   private TargetSystem targetSystem;
   
   private WeaponController weapon; 
   private bool dead;
   private int health; 

   private int deadLayer;

   private Rigidbody2D rb;

   private Vector3 damageVector;

   private void Awake() {
    health = 100;
    dead = false; 
    movePosition = GetComponent<UnitController>();
    unionAnim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    targetSystem = GetComponent<TargetSystem>();
    selectedSprite = transform.Find("SelectedSprite").gameObject;
    SetSelectedVisible(false);
    deadLayer = LayerMask.NameToLayer("DeadBodies");
   }

   public void SetSelectedVisible(bool visible) {
    selectedSprite.SetActive(visible);
   }

   public void MoveOrder(Vector3 position) {
    movePosition.setMovePosition(position); 
   }

   public void setDamageVector(Vector3 damageVector){
      this.damageVector = damageVector;
   }

   public bool getDeathState(){
      return dead;
   }
   private void Death(){
      StartCoroutine(deathVelocity(new Vector2 (damageVector.x,damageVector.y)));
      gameObject.layer = deadLayer;
      movePosition.enabled = false; 
      dead = true;
      targetSystem.enabled = false; 
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


   public IEnumerator deathVelocity(Vector2 deathVector){

    rb.velocity = deathVector* 3f;
    
    yield return new WaitForSeconds(.3f);

    rb.velocity = new Vector2 (0f,0f);

    yield return null;
   }

}
