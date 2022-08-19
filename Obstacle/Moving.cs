using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace Obstacle
{
    public class Moving : MonoBehaviour
    {
        public float speed;
        //private int mod;

        private void Start()
        {
            if ((int) ScoreManager.Instance.GetScore() > 25)
            {
                speed = 13;
            }

            if ((int) ScoreManager.Instance.GetScore() > 50)
            {
                speed = 15;
            }

            if ((int) ScoreManager.Instance.GetScore() > 75)
            {
                speed = 17;
            }

            if ((int) ScoreManager.Instance.GetScore() > 100)
            {
                speed = 20;
            }
            
            SetSpawnTime();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        private void SetSpawnTime()
        {
            var time = 2.0f;
            time -= (speed - 10) * 0.1f;
            
            SpawnObstacle.Instance.waitTime = time;
            
        }
    }
}