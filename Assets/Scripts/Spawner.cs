using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bottlePrefab;
    public float spawnInterval = 3f; // Раз на скільки секунд з'являється пляшка
    
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            SpawnBottle();
            timer = 0f;
        }
    }

    void SpawnBottle()
    {
        // Створюємо пляшку в координатах цього Спавнера
        Instantiate(bottlePrefab, transform.position, transform.rotation);
    }
}