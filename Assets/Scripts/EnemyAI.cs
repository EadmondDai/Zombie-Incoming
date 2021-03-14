using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void DoChase()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move"); 
        agent.SetDestination(target.position);
    }

    void TryChaseTarget()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            EngageTarget();
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= agent.stoppingDistance)
        {
            DoChase();
        }

        if(distanceToTarget <= agent.stoppingDistance)
        {
            Attack();    
        }
    }

    void Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log(name + " is attacking " + target.name);
    }

    // Update is called once per frame
    void Update()
    {
        TryChaseTarget();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
