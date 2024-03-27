using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HeadQuaters : MonoBehaviour
{
    //Variables 
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject soldierPrefab;
    [SerializeField] GameObject machineGunnerPrefab; 
    [SerializeField] GameObject artyPrefab; 
    [SerializeField] GameObject artyPoints; 
    [SerializeField] GameObject spawnPoints; 
    [SerializeField] public int startSoldiers = 3; 

    //Event Listeners
    void OnEnable() {
    Messenger<int>.AddListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought); 
    Messenger.AddListener(GameEvent.ARTY_BOUGHT,OnArtyBought); 
    Messenger.AddListener(GameEvent.MACHINE_GUNNER_BOUGHT,OnGunnerBought); 

   }

   void OnDisable() {
    Messenger<int>.RemoveListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought); 
    Messenger.RemoveListener(GameEvent.ARTY_BOUGHT,OnArtyBought); 
    Messenger.RemoveListener(GameEvent.MACHINE_GUNNER_BOUGHT, OnGunnerBought); 
   }


    //Buy Sulodier unit function  
   private void OnSoldierBought(int score){

    int numSoldiers = 3; 

    while(numSoldiers >0){
    int i = UnityEngine.Random.Range(0,transform.childCount);

     UnityEngine.Vector3 spawnPos =transform.GetChild(i).gameObject.transform.position;

     GameObject newSoldier = Instantiate(soldierPrefab,spawnPos,quaternion.identity); 

     numSoldiers--; 
     }
    
   }

    //Buy Artillery Unit 
   private void OnArtyBought() {

    int i = UnityEngine.Random.Range(0,transform.childCount);

    UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

    GameObject newSoldier = Instantiate(artyPrefab,spawnPos,quaternion.identity); 

   }

   private void OnGunnerBought() {

    int i = UnityEngine.Random.Range(0,transform.childCount);

    UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

    GameObject newSoldier = Instantiate(machineGunnerPrefab,spawnPos,quaternion.identity); 

   }





    // Start is called before the first frame update
    void Start()
    {

        while(startSoldiers > 0) {
            GameObject soldier = Instantiate(soldierPrefab,spawnPoint.position,quaternion.identity);
            startSoldiers--;
        }
 
    }
}
