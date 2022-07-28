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
            public GameObject boxEnemy, shootingEnemy;
            public float spawnTime;
            public float nextWaveTime;
            
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
        
        private float pauseTimer = 10;

        private GameObject spawnedEnemy;

        private int boxEnemyNum, shootingEnemyNum;

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
            boxEnemyNum = 0;
            shootingEnemyNum = 0;
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

                            if (pauseTimer > 0)
                            {

                            pauseTimer -= Time.deltaTime;

                                if (pauseTimer <= 0)
                                {
                                    round = 0;
                                    pauseTimer = 10;

                                    isSpawning = true;

                                    Spawn();
                                    NextWave();
                                    ChangeState();
                                
                                }
                            }
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
            
            boxEnemyNum += 1;
            shootingEnemyNum += 1;

            for (int i = 0; i < boxEnemyNum; i++)
            {
                
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(currentWave.boxEnemy, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
            }

            for (int i = 0; i < shootingEnemyNum; i++)
            {
                
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(currentWave.shootingEnemy, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
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
