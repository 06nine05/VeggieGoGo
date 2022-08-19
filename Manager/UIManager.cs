using Character;
using Obstacle;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        public int health;
        
        public GameObject gameOverPanel;
        public Text highScore;
        public Text cheat;
        public Player player;
        public Image[] hearts;

        // Update is called once per frame
        void Update()
        {
            health = player.Hp;

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].gameObject.SetActive(true);
                }
                else
                {
                    hearts[i].gameObject.SetActive(false);
                }
            }

            if (health > 3)
            {
                cheat.gameObject.SetActive(true);
            }
            
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                SpawnObstacle.Instance.StopSpawn();
                SoundManager.Instance.StopBGM();
                highScore.text = $"High Score : {PlayerPrefs.GetInt("HighScore", 0).ToString()}";
                gameOverPanel.SetActive(true);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}