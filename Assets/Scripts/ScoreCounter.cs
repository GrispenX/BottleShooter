using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Combo { get; private set; }
    public float Score { get; private set; }

    public void ResetCombo()
    {
        Combo = 0;
    }

    public void AddScore(float bottle_base, float accuracy)
    {
        
    }
}