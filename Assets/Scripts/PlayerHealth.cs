using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 150;
    [SerializeField] DisplayDamage dmageScript;

    private DeathHandler deathScript;

    // Start is called before the first frame update
    void Start()
    {
        deathScript = GetComponent<DeathHandler>();
    }

    public void OnHit(int damage)
    {
        dmageScript.OnImpact();
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            deathScript.OnDead();
        }
    }
}
