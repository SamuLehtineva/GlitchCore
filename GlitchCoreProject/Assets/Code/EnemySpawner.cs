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

        private float timer;

        private GameObject spawnedEnemy;

        int randomEnemy;

        int randomSpawnPoint;

        private int round = 0;

        private State state = State.WaitingForSpawn;

        void Start()
        {
            currentWave = waves[round];
            timer = currentWave.spawnTime;
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
                            NextWave();
                            ChangeState();
                            Debug.Log (round);
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

        private void Spawn()
        {
            for (int i = 0; i < currentWave.enemyNum; i++)
            {
                randomEnemy = Random.Range(0, currentWave.enemies.Length);
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);

                spawnedEnemy = Instantiate(currentWave.enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
            }
        }

        private void NextWave()
        {
            if (round + 1 <= 3)
            {
                round++;
                currentWave = waves[round];
            }
        }

        private void ChangeState()
        {
            state = state == State.WaitingForDestroy
                    ? State.WaitingForSpawn
                    : State.WaitingForDestroy;

            timer = currentWave.spawnTime;
        }
    }
}
