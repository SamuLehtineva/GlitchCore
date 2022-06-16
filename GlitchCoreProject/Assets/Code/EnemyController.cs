using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class EnemyController : MonoBehaviour
    {
        private PlayerController player;

        private NavMeshAgent enemy;

        // Start is called before the first frame update
        void Start()
        {
            enemy = GetComponent<NavMeshAgent>();
            player = GameObject.FindObjectOfType<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            Seek();
        }

        private void Seek()
        {
            enemy.SetDestination(player.transform.position);
        }

        public void OnTriggerEnter(Collider collider)
        {
            Bullet_1 bullet = collider.GetComponent<Bullet_1>();

            if (bullet != null)
            {
                Destroy (gameObject);
            }
        }
    }
}
