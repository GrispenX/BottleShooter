using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Аніматори пістолетів")]
    public Animator pistol_1; 
    public Animator pistol_2; 

  
    private bool isLeftTurn = true;

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

        if (laneIndex == 0 || laneIndex == 2 || laneIndex == 1)
        {
            if (isLeftTurn)
            {
                if (pistol_1 != null) pistol_1.Play("Pistol1_anim", 0, 0f);
            }
            else
            {
                if (pistol_2 != null) pistol_2.Play("Pistol2_anim", 0, 0f);
            }
            

            isLeftTurn = !isLeftTurn;
        }

    }
}