using System;
using Manager;
using Obstacle;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character
{
    public class Boss : BaseCharacter, IDamageable
    {
        [SerializeField] private Transform bulletPosL;
        [SerializeField] private Transform bulletPosR;
        [SerializeField] private AudioSource bulletAudioSource;

        public int scoreGive;
        
        private ScoreManager scoreManager;
        private Transform[] bulletPosRandom;
        public event Action OnKilled;

        private void Awake()
        {
            defaultBullet = BulletManager.Instance.GetEnemyBullet();
            scoreManager = FindObjectOfType<ScoreManager>();
            Hp = 100;
            bulletPosRandom = new[] {bulletPos, bulletPosL, bulletPosR};

            InvokeRepeating("Fire", 1, 1.5f);
        }

        public void SetBossHp(int hp)
        {
            Hp = hp;
        }

        public void TakeHit(int damage)
        { 
            Hp -= damage;
            
            SoundManager.Instance.Play(audioSource, SoundManager.Sound.BossHurt);
            
            if (Hp > 0)
            { 
                return;
            }

            Killed();
        }

        public void Killed()
        {
            SoundManager.Instance.PlayBossDie();
            gameObject.SetActive(false);
            Destroy(gameObject);
            OnKilled?.Invoke();
            scoreManager.score += scoreGive;
            
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlayBGM();

            SpawnObstacle.Instance.StartSpawn();
        }

        public override void Fire()
        {
            var bullet = Instantiate(defaultBullet, bulletPosRandom[Random.Range(0, bulletPosRandom.Length)].position, 
                Quaternion.identity);
            bullet.MoveDown();
            SoundManager.Instance.Play(bulletAudioSource, SoundManager.Sound.BossShoot);
        }
    }
}