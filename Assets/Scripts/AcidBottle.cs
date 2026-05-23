using UnityEngine;

public class AcidBottle : BaseBottle
{
    public readonly int damage = 50;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public override bool Hit(float accuracy)
    {
        GameManager.instance.scoreCounter.ResetCombo();
        GameManager.instance.healthCounter.RemoveHealth(damage);
        return true;
    }

    public override void End()
    {
        
    }
}