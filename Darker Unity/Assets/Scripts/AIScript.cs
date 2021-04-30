using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public float lookRadius = 10f;

    public Animator animator;

    private int playerDetectedID;

    public GameObject playerDetectedPrefab;

    public Transform target;
    NavMeshAgent agent;

    public Collider leftHurtbox;
    public Collider rightHurtbox;
    public int attackCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        playerDetectedID = Animator.StringToHash("PlayerDetected");
        animator.SetBool(playerDetectedID, false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            animator.SetBool(playerDetectedID, true);

            if (!FindObjectOfType<PlayerDetectedSound>())
            {
                Instantiate(playerDetectedPrefab, gameObject.transform.position + gameObject.transform.up * 0.75f, gameObject.transform.rotation, null);
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //Attack();
            }
        }

        else
        {
            animator.SetBool(playerDetectedID, false);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FiringLocation()
    {
        agent.SetDestination(PlayerManager.instance.player.transform.position);
    }

    /*void Attack()
    {
        if (attackCooldown == 10)
        {
            target.gameObject.GetComponent<HealthManager>().health -= 10;
            attackCooldown = 0;
        }
        else
        {
            attackCooldown++;
        }
    }*/
}
