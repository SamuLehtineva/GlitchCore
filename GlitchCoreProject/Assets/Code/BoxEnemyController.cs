using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class BoxEnemyController : MonoBehaviour, IHealth
    {
        public float maxHealth
		{
            get;
            set;
		}

        public float currentHealth
		{
            get;
            set;
		}

        public GameObject pulseAttack;
        public Transform spawnPoint;
        public float moveSpeed;
        public float attackDistance;

        bool isMoving;
        bool canAttack;
        private PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;

        void Awake()
        {
            canAttack = false;
            StartCoroutine(AttackDelay());
            navAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
            animator = GetComponentInChildren<Animator>();
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

            if (navAgent.remainingDistance < 2 && canAttack)
			{
                Attack();
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
            Instantiate(pulseAttack, spawnPoint.position, transform.rotation, transform);
            StartCoroutine(AttackDelay());
		}

        public void Damage(int amount)
		{
            currentHealth = -amount;
            if (currentHealth <= 0)
			{
                Die();
			}
		}

        public void Die()
		{
            Destroy(this.gameObject);
		}

        IEnumerator AttackDelay()
		{
            yield return new WaitForSeconds(1.25f);
            navAgent.speed = moveSpeed;
            canAttack = true;
		}
    }
}
