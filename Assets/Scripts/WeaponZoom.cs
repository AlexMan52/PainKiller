using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] FirstPersonController fpsController;

    bool isZooming;

    private void OnDisable()
    {
        ZoomOut();
    }
    void Update()
    {
        if (Input.GetButton("Fire2"))
        { 
            ZoomIn();
        }
        else
        {
           ZoomOut();
        }

    }

    void ZoomIn()
    {
        isZooming = true;
        playerCam.fieldOfView = 30f;
        fpsController.m_MouseLook.XSensitivity = 0.3f;
        fpsController.m_MouseLook.YSensitivity = 0.3f;

    }
    public void ZoomOut()
    {
        playerCam.fieldOfView = 60f;
        isZooming = false;
        fpsController.m_MouseLook.XSensitivity = 1f;
        fpsController.m_MouseLook.YSensitivity = 1f;
    }


}
