using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class MainMenuManager : Singleton<MainMenuManager>
    {
        [SerializeField] private string Url;
        [SerializeField] private RectTransform panel;
        [SerializeField] private RectTransform howToPlay;
        [SerializeField] private RectTransform itemList;
        [SerializeField] private RectTransform shopPanel;
        [SerializeField] private Text highScore;

        private void Start()
        {
            highScore.text = $"High Score : {PlayerPrefs.GetInt("HighScore", 0).ToString()}";
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void ConfirmQuit()
        {
            panel.gameObject.SetActive(true);
        }

        public void HowToPlay()
        {
            howToPlay.gameObject.SetActive(true);
        }

        public void ExitHowToPlay()
        {
            howToPlay.gameObject.SetActive(false);
        }

        public void ItemList()
        {
            itemList.gameObject.SetActive(true);
        }

        public void ExitItemList()
        {
            itemList.gameObject.SetActive(false);
        }

        public void Shop()
        {
            shopPanel.gameObject.SetActive(true);
        }
        
        public void ExitShop()
        {
            shopPanel.gameObject.SetActive(false);
        }

        public void Cancel()
        {
            panel.gameObject.SetActive(false);
        }

        public void Open()
        {
            Application.OpenURL(Url);
        }
        
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
    }
}