using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Latest soldier targeting script. Overlapcircle hit detection and calculates closest point to the unit
*/
public class V4_Target_System : MonoBehaviour
{
    private V4_Weapon_Con weapon;

    private Vector3 enemyPos;
    private List<Vector3> targetPosList;

    public float radius = 50f;

    private void Awake()
    {
        weapon = GetComponent<V4_Weapon_Con>();
        targetPosList = new List<Vector3>();
    }

    //Enemy detection code
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
                    //enemyPos = enemy.transform.position;
                    // StartCoroutine(weapon.Fire(enemyPos));
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

    //returns back closest enemy
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
