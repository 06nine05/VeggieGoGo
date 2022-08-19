using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public Text scoreText;
        public Text distanceText;
        public float distance;
        public float score;

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                distance += Time.deltaTime;

                score += Time.deltaTime / 10;

                scoreText.text = $"Score : {((int) score).ToString()}";
                distanceText.text = $"Distance : {((int) distance).ToString()}";
                if (score > PlayerPrefs.GetInt("HighScore",0))
                {
                    PlayerPrefs.SetInt("HighScore", (int)score);
                }
            }
        }

        public float GetScore()
        {
            return score;
        }

        public float GetDistance()
        {
            return distance;
        }
    }
}