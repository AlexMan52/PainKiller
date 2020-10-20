using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent navMeshAgent;

    [SerializeField] float chaseRange = 3f;
    float DistanceToTarget = Mathf.Infinity;

    [SerializeField] float attackRange = 5f;

    [SerializeField] float turnSpeed = 1f;

    bool isProvoked;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (GetComponent<Enemy>().isAlive)
        {
            CheckingForProvokes();
        }
    }
    
    private void CheckingForProvokes()
    {
        DistanceToTarget = (target.position - transform.position).sqrMagnitude;
        if (isProvoked)
        {
            EngageTarget();
        }
        else
        {
            isProvoked = false;
            GetComponent<Animator>().SetTrigger("Idle");
        }
        if (DistanceToTarget <= chaseRange * chaseRange)
        {
            isProvoked = true;
        }
        else
        {
            isProvoked = false;
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            isProvoked = true;
            StartCoroutine(CalmDown());
        }*/
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    IEnumerator CalmDown()
    {
        yield return new WaitForSecondsRealtime(3f);
        isProvoked = false;
    }

    private void EngageTarget()
    {
        FaceToTarget();
        if (DistanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaiseTarget();
        }
        if (DistanceToTarget < attackRange * attackRange)
        {
            AttackTarget();
        }
    }

    private void ChaiseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

   
}
