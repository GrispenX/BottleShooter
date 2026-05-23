using UnityEngine;

public class DefaultBottle : BaseBottle
{
    public readonly int basePoints = 10;
    public readonly int damage = 20;

    public override bool Hit(float accuracy)
    {
        GameManager.instance.scoreCounter.AddScore(basePoints, accuracy);
        return true;
    }

    public override void End()
    {
        GameManager.instance.scoreCounter.ResetCombo();
        GameManager.instance.healthCounter.RemoveHealth(damage);
    }
}