using UnityEngine;

public class HealBottle : BaseBottle
{
    public readonly int basePoints = 10;
    public readonly int heal = 10;
    public readonly int damage = 10;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public override bool Hit(float accuracy)
    {
        GameManager.instance.scoreCounter.AddScore(basePoints, accuracy);
        GameManager.instance.healthCounter.AddHealth(heal);
        return true;
    }

    public override void End()
    {
        GameManager.instance.scoreCounter.ResetCombo();
        GameManager.instance.healthCounter.RemoveHealth(damage);
    }
}