using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace breakout
{
    public class PaddleController : MonoBehaviour
    {
        public float speed = 15f;
        public float boundary = 24f;

        void Update()
        {
            float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

            // Pozisyon s�n�rlar�n� kontrol et
            if (newPosition.x > boundary)
            {
                newPosition.x = boundary;
            }
            else if (newPosition.x < -0.2f)
            {
                newPosition.x = -0.2f;
            }

            transform.position = newPosition;
        }
    }


}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PaddleController : MonoBehaviour
//{
//    public float speed = 15f;
//    public float boundary = 9.5f;

//    void Update()
//    {
//        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
//        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);
//        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);
//        transform.position = newPosition;
//    }
//}

