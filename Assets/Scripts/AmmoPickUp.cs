using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        other.GetComponent<Ammo>().IncreaseCurAmmo(ammoType, ammoAmount);

        Destroy(gameObject);
    }
}
