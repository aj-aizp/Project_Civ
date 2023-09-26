using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField] 
    Transform spawn;

    [SerializeField] 
    GameObject enemyPrefab;
    
private List<GameObject> enemiesList = new List<GameObject>();
public int numEnemies = 1;

void Start() {

    while(numEnemies>0) {
        GameObject newEnemy = Instantiate(enemyPrefab,spawn.position,quaternion.identity);
        newEnemy.GetComponent<EnemyAI>().setEnemyID(numEnemies);
        enemiesList.Add(newEnemy);

        numEnemies--;
    }

}

    // Update is called once per frame
    void Update()
    {

        
    }
}
