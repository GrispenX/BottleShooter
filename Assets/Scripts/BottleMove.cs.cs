using UnityEngine;

public class BottleMove : MonoBehaviour
{
    public float speed = 5f;
    // Координата осі (наприклад Z), після якої пляшка вважається такою, що "впала"
    public float fallPositionZ = -10f; 

    void Update()
    {
        // Рухаємо пляшку. 
        // В залежності від того, куди повернутий ваш конвеєр, можливо доведеться змінити Vector3.back на Vector3.forward або Vector3.left
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Перевірка на падіння (пропуск)
        if (transform.position.z < fallPositionZ) 
        {
            Debug.Log("Пляшка впала! Промах!");
            Destroy(gameObject);
        }
    }
}
