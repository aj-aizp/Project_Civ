using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnSystem : MonoBehaviour
{
[SerializeField] GameObject enemyPrefab;

private List<GameObject> enemiesList = new List<GameObject>();
public int numEnemies = 0;

private int x; 

    void OnEnable() {
        Messenger.AddListener(GameEvent.WAVE_SPAWN, WaveSpawn); 
   }

   void OnDisable() {
    Messenger.RemoveListener(GameEvent.WAVE_SPAWN, WaveSpawn); 
   }


   private void WaveSpawn (){
    x +=1; 
    numEnemies = SpawnCurve(x); 

    Debug.Log(numEnemies);

    while(numEnemies >0){

    int i = UnityEngine.Random.Range(0,transform.childCount);

     UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

     GameObject newEnemy = Instantiate(enemyPrefab,spawnPos,quaternion.identity); 
     numEnemies--; 
     }

   }

void Start() {

    x = 1; 

    numEnemies = SpawnCurve(x); 

     while(numEnemies >0){

    int i = UnityEngine.Random.Range(0,transform.childCount);

     UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

     GameObject newEnemy = Instantiate(enemyPrefab,spawnPos,quaternion.identity); 
     numEnemies--; 
     }

}



private int SpawnCurve (int x) {
    int y = x * 10; 
    return y; 

}





}
