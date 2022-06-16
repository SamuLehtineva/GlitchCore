using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GC.GlitchCoreProject
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        private NavMeshAgent enemy;

        // Start is called before the first frame update
        void Start()
        {
            enemy = GetComponent<NavMeshAgent>();
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
    }
}
