using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HeadQuaters : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;

    [SerializeField] GameObject soldierPrefab;

    public int numSoldiers; 



    // Start is called before the first frame update
    void Start()
    {

        while(numSoldiers > 0) {
            GameObject soldier = Instantiate(soldierPrefab,spawnPoint.position,quaternion.identity);
            numSoldiers--;
        }


        
    }


}
