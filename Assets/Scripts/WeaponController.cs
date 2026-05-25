using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator pistol_2;
    public Animator pistol_1;
    private int lastPistol = 1;

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
        if(lastPistol == 1)
        {
            pistol_2.SetTrigger("Shoot");
            lastPistol = 2;
        }
        else
        {
            pistol_1.SetTrigger("Shoot");
            lastPistol = 1;
        }
    }
}