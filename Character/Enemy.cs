using System;
using System.Collections;
using Manager;
using UnityEngine;

namespace Character
{
    public class Enemy : BaseCharacter, IDamageable
    {
        public int scoreGive;
        private ScoreManager scoreManager;
        public event Action OnKilled;

        private void Awake()
        {
            defaultBullet = BulletManager.Instance.GetEnemyBullet();
            scoreManager = FindObjectOfType<ScoreManager>();
            
            InvokeRepeating("Fire", 1, 1.5f);
        }

        public void TakeHit(int damage)
        {
            Hp -= damage;

            if (Hp > 0)
            {
                return;
            }

            Killed();
        }

        public void Killed()
        {
            SoundManager.Instance.PlayEnemyDie();
            gameObject.SetActive(false);
            Destroy(gameObject);
            OnKilled?.Invoke();
            scoreManager.score += scoreGive;
        }

        public override void Fire()
        {
            //var bullet = Instantiate(defaultBullet, bulletPos.position, Quaternion.identity);
            //bullet.MoveDown();
            //SoundManager.Instance.Play(audioSource, SoundManager.Sound.EnemyShoot);
        }

    }
}