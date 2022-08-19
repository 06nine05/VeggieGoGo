using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField] protected Transform bulletPos;
        [SerializeField] protected AudioSource audioSource;
        public int Hp;
        public Bullet defaultBullet;

        public abstract void Fire();
    }
}
