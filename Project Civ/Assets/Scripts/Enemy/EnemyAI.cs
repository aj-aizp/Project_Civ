using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private Color _flashColor = Color.white;
    private float flashtime; 

    private Coroutine DamageFlashCoroutine; 

    private SpriteRenderer sprite; 
    private Animator enemyAnim; 
    private EnemyTargetSystem weaponTarget;
    private Rigidbody2D rb; 
    private GameObject target; 

    private Vector3 DamageVector; 

     private int enemyID;
    public int enemyHealth; 
    private float speed; 

    private int deadLayer;

    private bool isFiring; 

    private bool dead;


    private void setSpeed(float speed){
        float speedOffset = UnityEngine.Random.Range(0.000f,0.008f);
        
        this.speed = speed + speedOffset;
    }

    private float getSpeed(){
        return speed; 
    }

    public void setDamageVector(Vector3 DamageVector){
        this.DamageVector = DamageVector;
    }

    public void setIsFiring(bool isFiring){
        this.isFiring = isFiring; 
    }

    public bool getIsFiring(){
        return isFiring;
    }

    public int getEnemyID() {
        return enemyID;
    }

    public void setEnemyID(int enemyID){
     enemyID = this.enemyID;
    }

    public bool getDeadState(){
        return dead;
    }

    public int getEnemyHealth (){
        return enemyHealth;
    }

    public void setEnemyHealth (int enemyHealth){
        this.enemyHealth = enemyHealth;
    }

    public void damage (int damage) {
        this.enemyHealth -=damage;
        CallDamageFlash(); 
    }

    private void SetFlashColor() {
    sprite.material.SetColor("_FlashColor", _flashColor); 
    }

    private void SetFlashAmount(float flashAmount) { 
        sprite.material.SetFloat("_FlashAmount",flashAmount); 

    }

    public void CallDamageFlash() {
        DamageFlashCoroutine = StartCoroutine (DamageFlash()); 
    }

    private void Awake() {
        setSpeed(0.003f);
        enemyHealth = 100; 
        flashtime = 0.25f; 
        dead = false;
        isFiring = false; 
        sprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        weaponTarget = GetComponent<EnemyTargetSystem>();
        rb = GetComponent<Rigidbody2D>();
        deadLayer = LayerMask.NameToLayer("DeadBodies");
        target = GameObject.Find("HQ");
    }

//Sets Enabled to be false, which disables Update function from being called. Then rotates the object and then destroyed after delay. 
    private void Death(){
        StartCoroutine(deathVelocity(new Vector2(DamageVector.x,DamageVector.y)));
        gameObject.layer = deadLayer;
        dead = true;
        enemyAnim.enabled = false; 
        weaponTarget.enabled = false;
        enabled = false;
        transform.rotation = Quaternion.Euler(0,0,90);
       
        Destroy(gameObject,5f);
    }


   public IEnumerator deathVelocity(Vector2 deathVector){

    rb.velocity = deathVector *2f; 

    yield return new WaitForSeconds(.3f);

    rb.velocity = new Vector2 (0f,0f);

    yield return null;
   }

   private IEnumerator DamageFlash() {

    //set color 
    SetFlashColor(); 

    //lerp flash amount
    float currentFlashAmount = 0f; 
    float elapsedTime = 0f;
    while(elapsedTime < flashtime) {
        elapsedTime += Time.deltaTime; 
        currentFlashAmount = Mathf.Lerp(1f,0f,elapsedTime/flashtime); 
        SetFlashAmount(currentFlashAmount); 
         yield return null; 
    }
   
   }

   


    private void Update() {
        if(enemyHealth <=0){
          Death(); 
        }

    if(target!=null && isFiring==false) {
     transform.position = Vector3.MoveTowards(transform.position,target.transform.position,speed+Time.deltaTime); 
     }
    }

    


}
