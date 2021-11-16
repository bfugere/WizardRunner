using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

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
        {
            navMeshAgent.speed = 0f;
            animator.SetBool("isIdling", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);
            Destroy(gameObject, 2.5f);
        }
    }
}
