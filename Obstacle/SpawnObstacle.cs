using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacle
{
    public class SpawnObstacle : Singleton<SpawnObstacle>
    {
        public GameObject[] obstaclePattern;
        public Transform spawnerPos;
        public float waitTime = 2.0f;

        private bool active;
        private GameObject obstacle;

        private void Start()
        {
            active = true;
            Spawn();
        }

        public void Spawn()
        {
            obstacle = Instantiate(obstaclePattern[Random.Range(0, obstaclePattern.Length)], spawnerPos.position,
                Quaternion.identity);

            if (active == false)
            {
                return;
            }
            
            StartCoroutine(wait());
        }

        public void StopSpawn()
        {
            active = false;
        }

        public void StartSpawn()
        {
            active = true;
            Spawn();
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(waitTime);
            Spawn();
        }
    }
}