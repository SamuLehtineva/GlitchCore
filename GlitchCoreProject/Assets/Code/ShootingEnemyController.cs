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

        private PlayerController player;
        private NavMeshAgent navAgent;
        private Animator animator;
        private EnemyStats stats;

        void Awake()
        {
            navAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
            animator = GetComponentInChildren<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Seek();

            if (navAgent.remainingDistance < attackDistance)
            {
                animator.SetTrigger("Attack");
            }
        }

        private void Seek()
        {
            navAgent.SetDestination(player.transform.position);
        }
    }
}
