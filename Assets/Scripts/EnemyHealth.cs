using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    bool isDead = false;

    public void OnHit(int damage)
    {
        if (isDead) return;
        if (damage <= 0) return;
        health -= damage;

        BroadcastMessage("OnTakeDamage", damage);

        if(health <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<NavMeshAgent>().speed = 0;
            isDead = true;
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
