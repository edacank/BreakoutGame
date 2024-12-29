using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
namespace breakout
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Transform ballSpawnPoint;

        [Header("Game Settings")]
        private int totalBlocks;
        private int destroyedBlocks = 0;
        private int activeBallsCount = 0;
        
        private bool isWinning;

        [Header("UI Panels")]
        [SerializeField] private UIManager uiManager; // UIManager'ı buraya ekliyoruz

        [Header("Extra Ball Settings")]
        [SerializeField] private int blocksToSpawnNewBall = 1;

        private int score = 0; // Skor tutucu
        private void Awake(){

            totalBlocks = GameObject.FindGameObjectsWithTag("Brick").Length;
        }
        private void Start()
        {
           // uiManager.HideAllPanels();

            BallController[] existingBalls = FindObjectsOfType<BallController>();
            foreach (BallController ball in existingBalls)
            {
                ball.Initialize(this); // Topları başlat
                activeBallsCount++;
            }

            // İlk topu oluştur
            SpawnBall();
        }

        public void AddScore(int points)
        {
            score += points;
            Debug.Log("Güncel Skor: " + score);

            destroyedBlocks++;
            if (destroyedBlocks % blocksToSpawnNewBall == 0)
            {
                SpawnBall();
            }

            
        }

        public void BallDestroyed()
        {
            int count = GameObject.FindGameObjectsWithTag("Ball").Length;
			activeBallsCount = count;
            activeBallsCount--;

            Debug.Log($"Kalan Top Sayısı: {activeBallsCount}");

            if (activeBallsCount <= 0 && !isWinning) // Tüm toplar sahneden çıktıysa
            {
                 // Oyunu bitir
                uiManager.ShowLosePanel();
            }
        }

      
        private void SpawnBall()
        {
            if (ballPrefab == null)
            {
                Debug.LogError("Ball prefab atanmamış!");
                return;
            }

            GameObject ball = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
            BallController ballController = ball.GetComponent<BallController>();
            if (ballController != null)
            {
                ballController.Initialize(this); // Yeni topu başlat
                activeBallsCount++;
            }
        }
    }
}