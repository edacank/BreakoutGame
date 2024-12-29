using UnityEngine;

namespace breakout
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody rb;
        private GameManager gameManager;
        private Vector3 initialDirection = new Vector3(1f, 1f, 1f); // X, Y ve Z ekseninde hareket
        private void Awake()
		{
			rb = GetComponent<Rigidbody>();
            
        }
		
        private void Start()
        {
            
            if (rb == null)
            {
                Debug.LogError("Rigidbody bileşeni bulunamadı!");
                return;
            }

            // Başlangıç hareketi
            rb.velocity = initialDirection.normalized * 10f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Brick"))
            {
                // Brick nesnesini yok et
                Destroy(collision.gameObject);

                // Skoru artır
                FindObjectOfType<GameManager>().AddScore(1);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BottomWall")) // Alt duvar olarak etiketlenen nesne
            {
                FindObjectOfType<GameManager>().BallDestroyed(); // GameManager'a topun düştüğünü bildir
                Destroy(gameObject); // Topu sahneden kaldır
            }
        }

        // Başlatma metodu (Opsiyonel, GameManager ile ilişkilendirmek için)
        public void Initialize(GameManager gameManager)
        {
            Debug.Log("Top GameManager ile başlatıldı.");
        }
    }
}