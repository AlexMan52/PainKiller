using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    private void Start()
    {
        ammoSlot = FindObjectOfType<Ammo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ammoSlot.AddAmmo(ammoType);
            Destroy(gameObject);
        }
    }



}
