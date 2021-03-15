using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] int damage = 30;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();    
    }

    public void AttackHitEvent()
    {
        if (playerHealth == null) return;
        playerHealth.GetComponent<PlayerHealth>().OnHit(damage);

    }

    public void OnTakeDamage(int damage)
    {
        //TODO we could add hit reaction, like faster attack, stop for a second
    }
}
