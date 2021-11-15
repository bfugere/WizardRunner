using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 25f;
    
    void Start()
    {
        
    }

    void AttackHitEvent()
    {
        if (target == null)
            return;

        Debug.Log("Hit");
    }
}
