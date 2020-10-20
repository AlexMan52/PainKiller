using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas deathCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        deathCanvas.enabled = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame

    public void ShowDeathCanvas()
    {
        deathCanvas.enabled = true;
        
        var fpsCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = fpsCamera.m_MouseLook;
        mouseLook.SetCursorLock(false);
        fpsCamera.enabled = false;

        GetComponentInChildren<Weapon>().enabled = false;

        Time.timeScale = 0.1f;
        FindObjectOfType<SwitchWeapon>().enabled = false;
    }
}
