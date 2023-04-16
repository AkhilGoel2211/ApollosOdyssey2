using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent enemyMesh = null;
    private Transform player;
    private Animator animator = null;
    private float enemyAttackSpeed = 1.5f;
    private int enemyDamage = 1;
    private float lastAttackedAt;
    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("PlayerArmature").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        float distance = Vector3.Distance(transform.position, player.position);
    
        if(distance <= enemyMesh.stoppingDistance)
        {
          
            facePlayer();
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", true);
            if(Time.time > lastAttackedAt + enemyAttackSpeed)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(enemyDamage);
                lastAttackedAt = Time.time;
            }
           
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", true);
            MoveToPlayer();
        }

    }

    private void MoveToPlayer()
    {
        enemyMesh.SetDestination(player.position);
    }

    private void facePlayer()
    {
        transform.LookAt(player);
    }
}
