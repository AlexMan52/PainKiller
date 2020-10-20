using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    //[SerializeField] float delayBetweenAttacks = 1f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }


    public void AttackHitEvent() //called in Animator
    {
        if (target == null) return;
        Debug.Log("bang!");
        target.TakeDamage(damage);
    }
}
