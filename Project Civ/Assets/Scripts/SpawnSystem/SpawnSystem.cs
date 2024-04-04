using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
Enemy spawn system 
*/
public class SpawnSystem : MonoBehaviour
{
[SerializeField] GameObject enemyPrefab;
private List<GameObject> enemiesList = new List<GameObject>();
private int numEnemies = 0;
private int x; 

    //Add listener for wavespawn event. broadcast every x number of seconds. 
    void OnEnable() {
        Messenger.AddListener(GameEvent.WAVE_SPAWN, WaveSpawn); 
   }

   void OnDisable() {
    Messenger.RemoveListener(GameEvent.WAVE_SPAWN, WaveSpawn); 
   }

    //spawn x number of enemies dependant on the spawn curve. 
   private void WaveSpawn (){
    x+=1; 
    numEnemies = SpawnCurve(x); 

    Debug.Log(numEnemies);

    while(numEnemies >0){

    int i = UnityEngine.Random.Range(0,transform.childCount);

     UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;
     GameObject newEnemy = Instantiate(enemyPrefab,spawnPos,quaternion.identity); 
     newEnemy.GetComponent<EnemyAI>().setEnemyHealth(100 + x*10); 
     numEnemies--; 
     }
   }

//at the start of the scene. Spawn an enemy wave. 
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

//every x number of seconds, enemy count increases by 10 
private int SpawnCurve (int x) {
    int y = x * 10; 
    return y; 

}
}
