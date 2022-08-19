using System;
using Manager;
using UnityEngine;

namespace Character
{
    public class Player : BaseCharacter, IDamageable
    {
        [SerializeField] private GameObject Barrier;
        [SerializeField] private AudioSource bulletAudioSource;
        [SerializeField] private AudioSource itemAudioSource;

        private Rigidbody2D rb;
        private Vector2 playerDirection;
        private float shootCoolDown = 0;
        private bool shield = false;
        private float defaultCoolDown = 0.7f;

        public int damageHit;
        public event Action OnKilled;

        void Awake()
        {
            defaultBullet = BulletManager.Instance.GetPlayerBullet();
            
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (shield)
            {
                Barrier.gameObject.SetActive(true);
            }

            if (shield == false)
            {
                Barrier.gameObject.SetActive(false);
            }
            
            if (shootCoolDown != 0)
            {
                shootCoolDown -= Time.deltaTime;
                if (shootCoolDown < 0)
                {
                    shootCoolDown = 0;
                }
            }

            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && transform.position.x > -1)
            {
                transform.Translate(-2, 0, 0);

                SoundManager.Instance.Play(audioSource, SoundManager.Sound.PlayerSwapLane);
            }

            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < 2)
            {
                transform.Translate(2, 0, 0);
                
                SoundManager.Instance.Play(audioSource, SoundManager.Sound.PlayerSwapLane);
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (shootCoolDown == 0) 
                {
                    Fire();

                    shootCoolDown = defaultCoolDown;
                }
            }

            if (Input.GetKeyDown(KeyCode.Home))
            {
                DebugHp();
            }
        }

        public override void Fire()
        {
            var bullet = Instantiate(defaultBullet, bulletPos.position, Quaternion.identity);
            bullet.Init();
            SoundManager.Instance.Play(bulletAudioSource, SoundManager.Sound.PlayerShoot);
        }

        public void TakeHit(int damage)
        {
            if (shield)
            {
                SoundManager.Instance.Play(itemAudioSource, SoundManager.Sound.ShieldBreak);
                
                shield = false;
            }
            
            else
            {
                SoundManager.Instance.Play(itemAudioSource, SoundManager.Sound.PlayerHurt);
                
                Hp -= damage;
                
                if (Hp > 0) 
                { 
                    return; 
                }
                
                Killed(); 
            } 
        }

        public void Killed()
        {
            SoundManager.Instance.PlayLose();
            Destroy(gameObject);
            OnKilled?.Invoke();
        }

        public int GetHP()
        {
            return Hp;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy" || other.tag == "Obstacle")
            {
                TakeHit(damageHit);

                Destroy(other.gameObject);
            }

            if (other.tag == "Heal")
            {
                SoundManager.Instance.Play(audioSource, SoundManager.Sound.Heal);
                
                if (Hp < 3)
                {
                    Hp++;
                }
                
                Destroy(other.gameObject);
            }

            if (other.tag == "Shield")
            {
                SoundManager.Instance.Play(audioSource, SoundManager.Sound.Shield);
                
                if (shield == false)
                {
                    shield = true;
                }
                
                Destroy(other.gameObject);
            }
        }

        private void DebugHp()
        {
            Hp = 999;
        }
    }
}