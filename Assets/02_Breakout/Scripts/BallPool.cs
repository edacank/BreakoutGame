using System.Collections.Generic;
using UnityEngine;
namespace breakout
{
    public class BallPool : MonoBehaviour
    {
        public GameObject ballPrefab; // Top prefab'�
        public int poolSize = 10; // Havuzdaki top say�s�

        private List<GameObject> ballPool; // Havuz listesi

        void Awake()
        {
            InitializePool();
        }

        void InitializePool()
        {
            ballPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject ball = Instantiate(ballPrefab);
                ball.SetActive(false); // Toplar� devre d��� b�rak
                ballPool.Add(ball); // Listeye ekle
            }
        }

        public GameObject GetBall()
        {
            // Listede devre d��� bir top var m� kontrol et
            foreach (var ball in ballPool)
            {
                if (!ball.activeInHierarchy) // E�er top aktif de�ilse
                {
                    ball.SetActive(true); // Topu etkinle�tir
                    return ball;
                }
            }

            // E�er t�m toplar aktifse, yeni bir top olu�tur ve listeye ekle
            Debug.LogWarning("T�m toplar aktif! Yeni top olu�turuluyor.");
            GameObject newBall = Instantiate(ballPrefab);
            newBall.SetActive(true);
            ballPool.Add(newBall);
            return newBall;
        }

        public void ReturnBall(GameObject ball)
        {
            ball.SetActive(false); // Topu devre d��� b�rak
                                   // Listeye tekrar eklemeye gerek yok, zaten listede var
        }
    }
}
