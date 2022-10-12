using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] bool chaseOnEnable = false;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        if (chaseOnEnable)
        {
            TryChaseTarget(GameObject.FindGameObjectWithTag("Player").transform);
        }

        GetComponentInChildren<Animator>().SetBool("Attack", false);
    }

    void DoChase()
    {
        FaceTarget();
        GetComponentInChildren<Animator>().SetBool("Attack", false);
        agent.SetDestination(target.position);
    }

    void TryChaseTarget(Transform newTarget = null)
    {
        if (newTarget)
            target = newTarget;

        if (target == null)
            return;

        if (!agent  || !agent.isOnNavMesh)
            return;

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
        FaceTarget();
        GetComponentInChildren<Animator>().SetBool("Attack", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.GetHealth() <= 0)
        {
            enabled = false;
            agent.enabled = false;
            return;
        }
        else
        {
            TryChaseTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 faceDirction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(faceDirction.x, 0, faceDirction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnTakeDamage(int damage)
    {
        isProvoked = true;
    }
}
