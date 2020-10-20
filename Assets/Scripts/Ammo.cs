﻿using System.Collections;
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
        public int ammoAmountMax;
        public int ammoToAdd;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }    
        }
        return null;
    }

    public void AddAmmo(AmmoType ammoType)
    {
        if (GetAmmoSlot(ammoType).ammoAmount < (GetAmmoSlot(ammoType).ammoAmountMax - GetAmmoSlot(ammoType).ammoToAdd))
        {
            GetAmmoSlot(ammoType).ammoAmount += GetAmmoSlot(ammoType).ammoToAdd;
        }
        else GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmountMax;
    }


}
