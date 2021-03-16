using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetAmmoAmount(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        return slot.ammoAmount;
    }

    public void DecreaseCurAmmo(AmmoType ammoType)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount--;
    }

    public void IncreaseCurAmmo(AmmoType ammoType, int ammoAmount)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
