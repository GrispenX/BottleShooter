using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public HitZone leftZone;
    public HitZone centerZone;
    public HitZone rightZone;

    void Update()
    {
        // Перевіряємо, чи натиснуті обидві кнопки одночасно (або одна затиснута, а інша клікнута)
        bool bothClicked = (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)) || 
                           (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)) ||
                           (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1));

        if (bothClicked)
        {
            centerZone.TryHit();
        }
        else if (Input.GetMouseButtonDown(0)) // Тільки Ліва кнопка
        {
            leftZone.TryHit();
        }
        else if (Input.GetMouseButtonDown(1)) // Тільки Права кнопка
        {
            rightZone.TryHit();
        }
    }
}