using UnityEngine;

public class FatBottle : BaseBottle
{
    public int basePoints = 20;
    public int hitsLeft = 2;
    public int damage = 40;

    public override bool Hit(float accuracy)
    {
        hitsLeft -= 1;
        GetComponent<Renderer>().material.color = Color.yellow;
        if(hitsLeft <= 0)
        {
            GameManager.instance.scoreCounter.AddScore(basePoints, accuracy);
            return true;
        }
        return false;
    }

    public override void End()
    {
        GameManager.instance.scoreCounter.ResetCombo();
        GameManager.instance.healthCounter.RemoveHealth(damage);
    }
}