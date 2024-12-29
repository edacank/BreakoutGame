using UnityEngine;

namespace breakout
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Transform ballSpawnPoint;
       private BallPool ballPool; // BallPool referans�
       
        void Start()
        {
            ballPool= FindObjectOfType<BallPool>(); // BallPool'u bul
        }
public void SpawnBall(Vector3 position)
{
    if (ballPool != null)
    {
        GameObject newBall = ballPool.GetBall(); // Havuzdan top al
        if (newBall != null)
        {
            newBall.transform.position = position; // Yeni topun pozisyonunu ayarla
            newBall.SetActive(true); // Topu aktif hale getir
            Rigidbody ballRb = newBall.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Rastgele bir hız ve yön uygula
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                ballRb.velocity = randomDirection * 5f; // Örnek hız
            }
        }
    }
    else
    {
        Debug.LogError("BallPool bulunamadı!");
    }
}



}
}
