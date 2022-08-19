using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class BackgroundLoop : MonoBehaviour
    {
        public float backgroundSpeed;
        public Renderer backgroundRenderer;

        // Update is called once per frame
        void Update()
        {
            if ((int) ScoreManager.Instance.GetScore() > 25)
            {
                backgroundSpeed = 0.75f;
            }

            if ((int) ScoreManager.Instance.GetScore() > 50)
            {
                backgroundSpeed = 0.9f;
            }

            if ((int) ScoreManager.Instance.GetScore() > 75)
            {
                backgroundSpeed = 1.05f;
            }

            if ((int) ScoreManager.Instance.GetScore() > 100)
            {
                backgroundSpeed = 1.2f;
            }

            backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
        }
    }
}