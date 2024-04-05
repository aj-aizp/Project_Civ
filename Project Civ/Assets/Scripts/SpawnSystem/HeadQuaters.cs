using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/*
Responsible for the shop system. Buy units here with the use of the event system. Spawnpoints are below the HQ sprite.
*/
public class HeadQuaters : MonoBehaviour
{
    // Field Variables
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject soldierPrefab;

    [SerializeField]
    GameObject machineGunnerPrefab;

    [SerializeField]
    GameObject artyPrefab;

    [SerializeField]
    GameObject artyPoints;

    [SerializeField]
    GameObject spawnPoints;

    [SerializeField]
    public int startSoldiers = 10;

    //Event Listeners
    void OnEnable()
    {
        Messenger<int>.AddListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought);
        Messenger.AddListener(GameEvent.ARTY_BOUGHT, OnArtyBought);
        Messenger.AddListener(GameEvent.MACHINE_GUNNER_BOUGHT, OnGunnerBought);
    }

    void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.SOLDIER_BOUGHT, OnSoldierBought);
        Messenger.RemoveListener(GameEvent.ARTY_BOUGHT, OnArtyBought);
        Messenger.RemoveListener(GameEvent.MACHINE_GUNNER_BOUGHT, OnGunnerBought);
    }

    //Buy Soldier unit function
    private void OnSoldierBought(int score)
    {
        int numSoldiers = 7;

        while (numSoldiers > 0)
        {
            int i = UnityEngine.Random.Range(0, transform.childCount);

            UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

            GameObject newSoldier = Instantiate(soldierPrefab, spawnPos, quaternion.identity);

            numSoldiers--;
        }
    }

    //Buy Artillery Unit
    private void OnArtyBought()
    {
        int i = UnityEngine.Random.Range(0, transform.childCount);

        UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

        GameObject newSoldier = Instantiate(artyPrefab, spawnPos, quaternion.identity);
    }

    //Buy Machine Gunner
    private void OnGunnerBought()
    {
        int numGunners = 3;

        while (numGunners > 0)
        {
            int i = UnityEngine.Random.Range(0, transform.childCount);

            UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;

            GameObject newSoldier = Instantiate(machineGunnerPrefab, spawnPos, quaternion.identity);

            numGunners--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        while (startSoldiers > 0)
        {
            int i = UnityEngine.Random.Range(0, transform.childCount);
            UnityEngine.Vector3 spawnPos = transform.GetChild(i).gameObject.transform.position;
            GameObject soldier = Instantiate(soldierPrefab, spawnPos, quaternion.identity);
            startSoldiers--;
        }
    }
}
