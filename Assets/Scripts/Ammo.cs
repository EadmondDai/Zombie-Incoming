using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 20;
    public int AmmoAmount { get { return ammoAmount; } }

    public void DecreaseCurAmmo()
    {
        ammoAmount--;
    }

}
