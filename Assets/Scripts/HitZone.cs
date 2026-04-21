using UnityEngine;

public class HitZone : MonoBehaviour
{
    [Header("Назва зони для логів (Left, Right, Center)")]
    public string zoneName;
    
    private GameObject bottleInZone = null;

    // Цей метод ми будемо викликати, коли гравець клікає мишкою
    public void TryHit()
    {
        if (bottleInZone != null)
        {
            Debug.Log($"[{zoneName}] Влучання! Пляшка розбита.");
            Destroy(bottleInZone); // Знищуємо пляшку
            bottleInZone = null;   // Очищаємо зону
        }
        else
        {
            Debug.Log($"[{zoneName}] Клік впусту!");
        }
    }

    // Коли пляшка заїжджає в зону
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle"))
        {
            bottleInZone = other.gameObject;
        }
    }

    // Коли пляшка виїжджає із зони (не встигли клікнути)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bottle"))
        {
            if (bottleInZone == other.gameObject)
            {
                bottleInZone = null;
            }
        }
    }
}