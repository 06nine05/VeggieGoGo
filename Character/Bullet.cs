using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private Transform transform;
        [SerializeField] public BulletType type;

        public enum BulletType
        {
            PlayerBullet,
            EnemyBullet
        }

        public void Init()
        {
            MoveUp();
        }

        private void Awake()
        {
            Debug.Assert(rb2D != null, "rb2D cannot be null");
            Debug.Assert(transform != null, "transform cannot be null");
        }

        private void Update()
        {
            if (transform.position.y > 13)
            {
                Destroy(gameObject);
            }
        }

        private void MoveUp()
        {
            rb2D.velocity = Vector2.up * speed;
        }

        public void MoveDown()
        {
            rb2D.velocity = Vector2.down * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.gameObject.GetComponent<IDamageable>();
            
            if (type == BulletType.PlayerBullet && other.tag == "Enemy" || type == BulletType.PlayerBullet && other.tag == "Boss" || type == BulletType.EnemyBullet && other.tag == "Player")
            {
                target?.TakeHit(damage);
                Destroy(gameObject);
            }
            
            if (other.tag == "Border")
            {
                Destroy(gameObject);
            }
        }
    }
}