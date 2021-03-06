using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class ShootingEnemyController : MonoBehaviour
    {
        public float moveSpeed;
        public float attackDistance;

        public PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;
        private EnemyStats stats;

        void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
            animator = GetComponentInChildren<Animator>();
            stats = GetComponent<EnemyStats>();
        }

        void Update()
        {
            Seek();

            if (navAgent.remainingDistance < attackDistance)
            {
                animator.SetTrigger("Attack");
                transform.LookAt(player.transform);
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

        public void Die()
        {
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(this);
        }
    }
}
