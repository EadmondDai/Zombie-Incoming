using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float angleRestoreThreshold = 35;
    [SerializeField] float insensityRestoreAmount = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        other.gameObject.GetComponentInChildren<FlashLight>().RestoreLight(angleRestoreThreshold, insensityRestoreAmount);
        Destroy(gameObject);
    }
}
