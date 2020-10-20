using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public bool isAlive = true;
    public void TakeDamage(float damage) //called in Weapon script
    {
        BroadcastMessage("OnDamageTaken"); //string reference!!!
        health -= damage;
        if (health <= Mathf.Epsilon)
        {
            Die();
        }
    }

    void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else return;
        
        //Destroy(gameObject);
    }

    

}
