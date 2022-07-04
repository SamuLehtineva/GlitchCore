using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject pulseAttack;
        public float moveSpeed;

        bool isMoving;
        private PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;

        void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
            animator = GetComponentInChildren<Animator>();
            navAgent.speed = moveSpeed;
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

            if (navAgent.remainingDistance < 2)
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
            animator.SetTrigger("Attack");
            navAgent.speed = 0;
            Instantiate(pulseAttack, transform.position, transform.rotation);
            StartCoroutine(AttackDelay());
		}

        IEnumerator AttackDelay()
		{
            yield return new WaitForSeconds(4);
            navAgent.speed = moveSpeed;
		}

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 7)
            {
                Destroy (gameObject);
            }
        }
    }
}
