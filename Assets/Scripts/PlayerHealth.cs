using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnHit(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Debug.Log("Arrrr, I am dead  ");
        }
    }
}
