using Character;
using UnityEngine;

namespace Manager
{
    public class BulletManager: Singleton<BulletManager>

    {
        [SerializeField] private Bullet playerBullet;
        [SerializeField] private Bullet enemyBullet;

        public Bullet GetPlayerBullet()
        {
            return playerBullet;
        }

        public Bullet GetEnemyBullet()
        {
            return enemyBullet;
        }
    }
}