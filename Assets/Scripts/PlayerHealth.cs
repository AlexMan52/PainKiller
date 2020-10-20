using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;

    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        damageCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage) //called in EnemyAttack script
    {
        StartCoroutine(ShowDamageImage());
        health -= damage;
        if (health <= Mathf.Epsilon)
        {
            GetComponent<DeathHandler>().ShowDeathCanvas();
        }
    }

    IEnumerator ShowDamageImage()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSecondsRealtime(0.3f);
        damageCanvas.enabled = false;

    }
}
