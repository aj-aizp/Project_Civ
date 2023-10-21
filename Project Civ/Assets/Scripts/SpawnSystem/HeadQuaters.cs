using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HeadQuaters : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;

    [SerializeField] GameObject soldierPrefab;

    [SerializeField] GameObject artyPrefab; 

    [SerializeField] public int startSoldiers = 3; 

    void OnEnable() {
    Messenger<int>.AddListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought); 
    Messenger.AddListener(GameEvent.ARTY_BOUGHT,OnArtyBought); 
   }

   void OnDisable() {
    Messenger<int>.RemoveListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought); 
    Messenger.RemoveListener(GameEvent.ARTY_BOUGHT,OnArtyBought); 
   }

   private void OnSoldierBought(int score){

    int numSoldiers = 3; 

    while(numSoldiers >0){

    int i = UnityEngine.Random.Range(0,transform.childCount);

     UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

     GameObject newSoldier = Instantiate(soldierPrefab,spawnPos,quaternion.identity); 
     numSoldiers--; 
     }
    
   }

   private void OnArtyBought() {

    int i = UnityEngine.Random.Range(0,transform.childCount);

    UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

     GameObject newSoldier = Instantiate(artyPrefab,spawnPos,quaternion.identity); 

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
