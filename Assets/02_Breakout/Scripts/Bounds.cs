using UnityEngine;

namespace breakout
{
    public class Bounds : MonoBehaviour
    {
       private BallSpawner ballSpawner; // BallSpawner referans�

        void Start()
        {
           ballSpawner = FindObjectOfType<BallSpawner>(); // BallSpawner'� sahnede bul
            if (ballSpawner == null)
            {
                Debug.LogError("BallSpawner bulunamad�! L�tfen sahnede bir BallSpawner objesi oldu�undan emin olun.");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Topun BallController scriptine sahip olup olmad���n� kontrol et
            BallController ball = other.GetComponent<BallController>();
            if (ball != null)
            {
                // Topu havuza geri g�nder
                ballSpawner.SpawnBall(ballSpawner.transform.position); // BallSpawner ile yeni top spawn et
            }
            else
            {
                Debug.LogWarning("�arpan nesne 'BallController' scriptine sahip de�il!");
            }
        }
    }
}

