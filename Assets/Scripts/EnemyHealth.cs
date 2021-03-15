using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void OnHit(int damage)
    {
        if (damage <= 0) return;
        health -= damage;

        BroadcastMessage("OnTakeDamage", damage);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
