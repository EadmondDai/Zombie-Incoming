using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 150;

    private DeathHandler deathScript;

    // Start is called before the first frame update
    void Start()
    {
        deathScript = GetComponent<DeathHandler>();
    }

    public void OnHit(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            deathScript.OnDead();
        }
    }
}
