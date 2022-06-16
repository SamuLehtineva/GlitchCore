using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EnemySpawner : MonoBehaviour
    {
        public enum State
        {
            WaitingForSpawn,
            WaitingForDestroy
        }

        [SerializeField]
        private float spawnTime;

        [SerializeField]
        private GameObject enemy;

        private float timer;

        private State state = State.WaitingForSpawn;

        private GameObject spawnedEnemy;

        void Start()
        {
            timer = spawnTime;
        }

        void Update()
        {
            switch (state)
            {
                case State.WaitingForSpawn:
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        if (timer <= 0)
                        {
                            Spawn();
                            ChangeState();
                            Debug.Log("not Destroyed");
                        }
                    }

                    break;

                case State.WaitingForDestroy:
                    if (spawnedEnemy == null)
                    {
                        ChangeState();
                    }
                    break;
                    
            }
        }

        private void ChangeState()
        {
            state =
                state == State.WaitingForDestroy
                    ? State.WaitingForSpawn
                    : State.WaitingForDestroy;

            timer = spawnTime;
        }

        private void DoDestroy()
        {
            Destroy (spawnedEnemy);
            spawnedEnemy = null;
        }

        private void Spawn()
        {
            spawnedEnemy = Instantiate(enemy, transform.position, transform.rotation);

        }
    }
}
