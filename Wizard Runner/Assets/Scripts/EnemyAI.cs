using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    Animator animator;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
            EngageTarget();
        else if (distanceToTarget <= chaseRange)
            isProvoked = true;
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
            ChaseTarget();

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    void ChaseTarget()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        animator.SetBool("isAttacking", true);
        Debug.Log(name + " is attacking " + target.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
