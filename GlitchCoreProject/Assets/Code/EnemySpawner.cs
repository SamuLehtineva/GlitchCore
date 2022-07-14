using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class EnemySpawner : MonoBehaviour
    {
        [System.Serializable]
        public class Wave
        {
            public GameObject[] enemies;

            public float spawnTime;

            public float nextWaveTime;

            public float enemyNum;
        }

        public enum State
        {
            WaitingForSpawn,
            WaitingForDestroy
        }

        [SerializeField]
        private Wave[] waves;

        private Wave currentWave;

        [SerializeField]
        private Transform[] spawnPoints;

        private float spawnTimer;

        private float destroyTimer;

        private GameObject spawnedEnemy;

        int randomEnemy;

        int randomSpawnPoint;

        private int round = 0;

        private bool isSpawning;

        private State state = State.WaitingForSpawn;

        void Start()
        {
            currentWave = waves[round];
            spawnTimer = currentWave.spawnTime;
            destroyTimer = currentWave.nextWaveTime;
            isSpawning = true;
        }

        void Update()
        {
            switch (state)
            {
                case State.WaitingForSpawn:
                
                    if (isSpawning)
                    {
                        if (spawnTimer > 0)
                        {
                            spawnTimer -= Time.deltaTime;
                            if (spawnTimer <= 0)
                            {
                                Spawn();
                                NextWave();
                                ChangeState();
                                Debug.Log (round);
                            }
                        }
                    }
                    else if (!isSpawning)
                    {
                        if (!IsAlive())
                        {
                            // waves stop
                        }
                    }

                    break;

                case State.WaitingForDestroy:

                    if (destroyTimer > 0)
                    {
                        destroyTimer -= Time.deltaTime;
                        if (destroyTimer <= 0 || !IsAlive())
                        {
                            ChangeState();
                        }
                    }
                    break;
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < currentWave.enemyNum; i++)
            {
                randomEnemy = Random.Range(0, currentWave.enemies.Length);
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(currentWave.enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
            }
        }

        private void NextWave()
        {
            if (round + 1 < waves.Length)
            {
                round++;
                currentWave = waves[round];
            }
            else
            {
                isSpawning = false;
            }
        }

        private bool IsAlive()
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

            return true;
        }

        private void ChangeState()
        {
            state = state == State.WaitingForDestroy
                    ? State.WaitingForSpawn
                    : State.WaitingForDestroy;

            spawnTimer = currentWave.spawnTime;
            destroyTimer = currentWave.nextWaveTime;
        }
    }
}
