using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnSystem : MonoBehaviour
{
[SerializeField] GameObject enemyPrefab;

private List<GameObject> enemiesList = new List<GameObject>();
public int numEnemies = 1;

void Start() {

    while(numEnemies >0){

   int i = UnityEngine.Random.Range(0,transform.childCount);

    UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

    GameObject newEnemy = Instantiate(enemyPrefab,spawnPos,quaternion.identity); 
    numEnemies--; 
    }

}
}
