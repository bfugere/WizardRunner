using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    public bool IsDead()
    {
        return isDead;
    }

    Animator animator;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("EnemyProvoked");
        hitPoints -= damage;

        if (hitPoints <= 0)
            Die();
    }

    void Die()
    {
        isDead = true;
        navMeshAgent.speed = 0f;
        animator.SetTrigger("isDead");
        Destroy(gameObject, 2.5f);

        // TODO: Add Random Drop Chances.
        // TODO: Add Death VFX.
    }
}
