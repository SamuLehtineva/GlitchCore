using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class BoxEnemyController : MonoBehaviour
    {
        public GameObject pulseAttack;
        public Transform spawnPoint;
        public float moveSpeed;
        public float attackDistance;

        bool isMoving;
        bool canAttack;
        private PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;
        private GameObject lastAttack;
        private EnemyStats stats;

        void Awake()
        {
            canAttack = false;
            StartCoroutine(AttackDelay());
            navAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
            animator = GetComponentInChildren<Animator>();
            stats = GetComponent<EnemyStats>();
        }

        void FixedUpdate()
        {
            Seek();

            if (navAgent.remainingDistance >  navAgent.stoppingDistance)
			{
                isMoving = true;
			}
            else
			{
                isMoving = false;
			}

            animator.SetBool("isMoving", isMoving);

            if (navAgent.remainingDistance < attackDistance && canAttack)
			{
                Attack();
			}

            if (stats.currentHealth <= 0)
            {
                Die();
            } 
        }

        private void Seek()
        {
            navAgent.SetDestination(player.transform.position);
        }

        void Attack()
		{
            canAttack = false;
            animator.SetTrigger("Attack");
            navAgent.speed = 0;
            lastAttack = Instantiate(pulseAttack, spawnPoint.position, transform.rotation, transform);
            StartCoroutine(AttackDelay());
		}

        public void Die()
        {
            Destroy(lastAttack);
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(this);
        }

        IEnumerator AttackDelay()
		{
            yield return new WaitForSeconds(1.25f);
            navAgent.speed = moveSpeed;
            canAttack = true;
		}
    }
}
