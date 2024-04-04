using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Target System for Machine Gunners. Not too desimilar to the target system of version 4 soldiers
*/
public class MachineGunner_Target : MonoBehaviour
{
    private MachineGunner_Weapon weapon;

    private Vector3 enemyPos;
    private List<Vector3> targetPosList;

    public float radius = 50f;

    private void Awake()
    {
        weapon = GetComponent<MachineGunner_Weapon>();
        targetPosList = new List<Vector3>();
    }

    //Overlap circle collider for enemy detection
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<EnemyAI>(out EnemyAI enemy))
            {
                if (enemy.getDeadState() == false)
                {
                    targetPosList.Add(enemy.transform.position);
                }
            }
        }

        if (targetPosList.Count > 1)
        {
            StartCoroutine(weapon.Fire(closestPoint(targetPosList)));
        }
        else if (targetPosList.Count == 1)
        {
            StartCoroutine(weapon.Fire(targetPosList[0]));
        }
        targetPosList.Clear();
    }

    //The closest enemy is the one targeted within the overlapCircle collider
    private Vector3 closestPoint(List<Vector3> targetPosList)
    {
        float tempDistance = 0f;
        float minDistance = Vector3.Distance(transform.position, targetPosList[0]);
        Vector3 closestPoint = targetPosList[0];

        foreach (Vector3 targetPos in targetPosList)
        {
            tempDistance = Vector3.Distance(transform.position, targetPos);
            if (tempDistance < minDistance)
            {
                closestPoint = targetPos;
            }
        }

        return closestPoint;
    }
}
