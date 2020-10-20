using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    bool isActive;
    float startIntensity = 0f;
    float maxIntensity = 5f;
    float currentIntensity;

    void Start()
    {
        GetComponent<Light>().intensity = startIntensity;
        currentIntensity = maxIntensity;
    }
    
    void Update()
    {
        SwitchOnAndOff();
        DecreasePower();
    }

    private void SwitchOnAndOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isActive)
            {
                isActive = true;
            }
            else
            {
                GetComponent<Light>().intensity = 0f;
                isActive = false;
            }
        }
    }

    private void DecreasePower()
    {
        if (isActive)
        {
            GetComponent<Light>().intensity = currentIntensity;
            currentIntensity -= 0.4f * Time.deltaTime;
        }
        
    }

    public void IncreasePower()
    {
        currentIntensity = maxIntensity;
    }
}
