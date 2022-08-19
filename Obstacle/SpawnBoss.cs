using System.Collections;
using Character;
using Manager;
using UnityEngine;

namespace Obstacle
{
    public class SpawnBoss : MonoBehaviour
    {
        public GameObject bossPre;
        public Transform spawnerPos;
        public float waitTime = 3.0f;
        
        private GameObject boss;
        private int distanceNeed = 40;
        private float distanceTimer = 40;
        private float deSpawnTime = 20;
        private float timer = 0;

        private void Update()
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null)
            {
                distanceTimer -= Time.deltaTime;
            }
            
            if (distanceTimer < 0)
            {
                Spawn();
            }

            if (GameObject.FindGameObjectWithTag("Boss") != null)
            {
                timer += Time.deltaTime;
            }

            if (timer > deSpawnTime)
            {
                DeSpawn();

                timer = 0;
            }

        }

        private void Spawn()
        {
            SpawnObstacle.Instance.StopSpawn();
            
            SoundManager.Instance.StopBGM();
                
            StartCoroutine(wait());

            SoundManager.Instance.PlayBossBGM();
            SoundManager.Instance.PlayBossVoice();

            distanceNeed += 20;

            distanceTimer = distanceNeed;
        }

        private void DeSpawn()
        {
            Destroy(boss);
            
            SoundManager.Instance.PlayBossVoice();
            SoundManager.Instance.StopBGM();

            SpawnObstacle.Instance.StartSpawn();
            SoundManager.Instance.PlayBGM();
        }
        
        IEnumerator wait()
        {
            yield return new WaitForSeconds(waitTime);
            boss = Instantiate(bossPre, spawnerPos.position, Quaternion.identity);
        }
        
    }
}