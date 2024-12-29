using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


namespace breakout
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Button playAgainButton;
        [SerializeField] private Button tryAgainButton;
        
        private bool isWinning;
        private void Awake()
        {
            // Butonlara işlev ekle
            playAgainButton.onClick.AddListener(RestartGame);
            tryAgainButton.onClick.AddListener(RestartGame);
        }

        private void Start()
		{
			HideAllPanels();

		}
        public void HideAllPanels()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
        }

        public void ShowWinPanel()
        {
           winPanel.SetActive(true);
           isWinning= true;
           Time.timeScale=0;
        }

        public void ShowLosePanel()
        {
           if (isWinning != true)
			{
				losePanel.SetActive(true);
				Time.timeScale = 0;
			}
        }
        
        
        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
