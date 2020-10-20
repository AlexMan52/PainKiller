using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float range = 100f;
    [SerializeField] GameObject shootingHitVFXPrefab;
    [SerializeField] ParticleSystem shootingFlashVFX;
    [SerializeField] Transform bulletPoint;
    [SerializeField] AudioClip shootingSFX;
    [SerializeField] AudioClip noAmmoSound;
    [SerializeField] float timeBetweenShots = 0f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;

    [SerializeField] Canvas gameplayUI;

    
    AudioSource audioSource;

    public float damage = 20f;

    bool isAbleToShoot = true;

    private void OnEnable()
    {
        isAbleToShoot = true;
    }

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAbleToShoot)
        {
            Shoot();
        }
        ShowAmmoAmount();

    }

    private void ShowAmmoAmount()
    {
        gameplayUI.GetComponentInChildren<Text>().text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator ShootingWithDelay()
    {
        isAbleToShoot = false;
        yield return new WaitForSecondsRealtime(timeBetweenShots);
        isAbleToShoot = true;
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceAmmo(ammoType);
            RaycastHit hitInfo;
            bool isHitted = Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hitInfo, range);
            PlayShootingEffects(hitInfo, isHitted);
            StartCoroutine(ShootingWithDelay());
        }
        else if (ammoSlot.GetCurrentAmmo(ammoType) <= 0)
        {
            audioSource.PlayOneShot(noAmmoSound);
        }

    }

    private void PlayShootingEffects(RaycastHit hitInfo, bool isHitted)
    {
        shootingFlashVFX.Play();
        audioSource.PlayOneShot(shootingSFX);

        if (isHitted)
        {
            Debug.Log("Hit " + hitInfo.transform.tag);
            GameObject hitVFXInstance = Instantiate(shootingHitVFXPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitVFXInstance, 1f);

            if (hitInfo.transform.tag == "Enemy")
            {
                hitInfo.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        else { return; }
    }

    private void AutoShoot()
    {
        StartCoroutine(AutoShooting());
    }
    IEnumerator AutoShooting()
    {
        yield return new WaitForSecondsRealtime(2f);
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hitInfo;
            bool isHitted = Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hitInfo, range);

            PlayShootingEffects(hitInfo, isHitted);

        }
        
    }

}
