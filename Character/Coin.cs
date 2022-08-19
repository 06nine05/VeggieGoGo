using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace Character
{
    public class Coin : MonoBehaviour
    {
        public int scoreGive;
        private ScoreManager scoreManager;

        private void Start()
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                scoreManager.score += scoreGive;
                
                SoundManager.Instance.PlayCoin();

                Destroy(gameObject);
            }
            
            else if (other.tag == "Border")
            {
                Destroy(gameObject);
            }
        }
    }
}