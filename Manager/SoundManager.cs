using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        public enum Sound
        {
            BGM,
            PlayerShoot,
            PlayerSwapLane,
            PlayerHurt,
            Lose,
            EnemyDie,
            BossSound,
            BossBGM,
            BossShoot,
            BossHurt,
            BossDie,
            Coin,
            Heal,
            Shield,
            ShieldBreak
        }

        [SerializeField] private SoundClip[] soundClips;
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            PlayBGM();
        }

        /// <summary>
        /// Play sound
        /// </summary>
        /// <param name="audioSource"></param>
        /// <param name="sound"></param>
        public void Play(AudioSource audioSource, Sound sound)
        {
            Debug.Assert(audioSource != null, "audioSource cannot be null");

            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }

        public void PlayBGM()
        {
            Play(bgmSource, Sound.BGM);
        }

        public void PlayBossBGM()
        {
            Play(bgmSource, Sound.BossBGM);
        }

        public void PlayLose()
        {
            Play(audioSource, Sound.Lose);
        }

        public void PlayEnemyDie()
        {
            Play(audioSource, Sound.EnemyDie);
        }

        public void PlayBossDie()
        {
            Play(audioSource, Sound.BossDie);
        }

        public void PlayBossVoice()
        {
            Play(audioSource, Sound.BossSound);
        }

        public void PlayCoin()
        {
            Play(audioSource, Sound.Coin);
        }

        public void Stop()
        {
            audioSource.Stop();
        }

        public void StopBGM()
        {
            bgmSource.Stop();
        }

        private AudioClip GetAudioClip(Sound sound)
        {
            foreach (var soundClip in soundClips)
            {
                if (soundClip.Sound == sound)
                {
                    return soundClip.AudioClip;
                }
            }

            Debug.Assert(false, $"Cannot find sound {sound}");
            return null;
        }

        [Serializable]
        public struct SoundClip
        {
            public Sound Sound;
            public AudioClip AudioClip;
        }
    }
}