using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 150;
    [SerializeField] DisplayDamage dmageScript;
    [SerializeField] TextMeshProUGUI healthText;

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

        healthText.text = playerHealth.ToString();

        if(playerHealth <= 0)
        {
            deathScript.OnDead();
        }
    }
}
