using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class EnemyController : MonoBehaviour
    {
        bool isMoving;
        private PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;

        void Start()
        {
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
        }

        private void Seek()
        {
            navAgent.SetDestination(player.transform.position);
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
