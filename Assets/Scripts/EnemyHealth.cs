using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void OnHit(int damange)
    {
        health -= damange;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
