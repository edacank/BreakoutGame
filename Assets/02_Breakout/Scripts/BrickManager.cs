using System.Collections.Generic;
using UnityEngine;
namespace breakout
{
public class BrickManager : MonoBehaviour
{
    // Prefab'lar için Dictionary
    public Dictionary<string, GameObject> brickPrefabs = new Dictionary<string, GameObject>();

    public int rows = 8; // Tuğla satırı
    public int columns = 9; // Tuğla sütunu
    public int layers = 3; // Tuğla katmanları (z ekseninde derinlik)
    public float brickWidth = 2.1f; // Tuğla genişliği
    public float brickHeight = 0.5f; // Tuğla yüksekliği
    public float brickDepth = 1.2f; // Tuğla derinliği (z ekseninde mesafe)
    public float horizontalSpacing = 0.1f; // Yatay boşluk
    public float verticalSpacing = 0.1f; // Dikey boşluk
    public float depthSpacing = 0.1f; // Z ekseninde derinlik boşluğu

    // Tuğla sırasını row olarak tanımlıyoruz
    private string[] brickRowPattern = new string[]
    {
        "Red", "Blue", "Red", "Green", "Yellow", "Green", "Red", "Blue", "Red"
    };

    void Start()
    {
        // Prefab'ları Dictionary'e ekliyoruz
        brickPrefabs.Add("Red", redBrickPrefab);
        brickPrefabs.Add("Blue", blueBrickPrefab);
        brickPrefabs.Add("Green", greenBrickPrefab);
        brickPrefabs.Add("Yellow", yellowBrickPrefab);

        // Tuğlaları oluşturuyoruz
        CreateBricks();
    }

    void CreateBricks()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < layers; k++) // Katmanlar (Z ekseninde)
                {
                    // Sıradaki tuğlanın rengini belirlemek için
                    string brickColor = brickRowPattern[j];

                    // Prefab'ı almak için Dictionary kullanıyoruz
                    GameObject brickPrefab = brickPrefabs[brickColor];

                    // Her tuğlayı doğru konumda oluşturuyoruz
                    // Yatayda, dikeyde ve z ekseninde boşluk ekliyoruz
                    float xPosition = j * (brickWidth + horizontalSpacing);
                    float yPosition = -i * (brickHeight + verticalSpacing);
                    float zPosition = k * (brickDepth + depthSpacing);

                    Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                    Instantiate(brickPrefab, position, Quaternion.identity);
                }
            }
        }
    }

    // Prefab referansları
    public GameObject redBrickPrefab;   // Kırmızı tuğla prefab'ı
    public GameObject blueBrickPrefab;  // Mavi tuğla prefab'ı
    public GameObject greenBrickPrefab; // Yeşil tuğla prefab'ı
    public GameObject yellowBrickPrefab;// Sarı tuğla prefab'ı
}
}