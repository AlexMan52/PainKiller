using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickUp : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<FlashlightSystem>().IncreasePower();
            Destroy(gameObject);
        }
    }
}
