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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void TryChaseTarget()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= chaseRange)
        {
            agent.SetDestination(target.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TryChaseTarget();
    }
}
