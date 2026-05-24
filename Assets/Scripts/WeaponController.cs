using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Аніматори пістолетів")]
    public Animator pistol_2;
    public Animator pistol_1;

    private void OnEnable()
    {
        PlayerInput.OnShoot += HandleShoot;
    }

    private void OnDisable()
    {

        PlayerInput.OnShoot -= HandleShoot;
    }

    private void HandleShoot(int laneIndex)
    {
        switch (laneIndex)
        {
            case 0: 
                if (pistol_2 != null) pistol_2.SetTrigger("Shoot");
                break;

            case 1: 

                if (pistol_2 != null) pistol_2.SetTrigger("Shoot");
                if (pistol_1 != null) pistol_1.SetTrigger("Shoot");
                break;

            case 2:
                if (pistol_1 != null) pistol_1.SetTrigger("Shoot");
                break;
        }
    }
}