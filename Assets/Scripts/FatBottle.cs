using UnityEngine;

public class FatBottle : BaseBottle
{
    public readonly int basePoints = 20;
    public int hitsLeft { get; private set; } = 2;
    public readonly int damage = 40;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public override bool Hit(float accuracy)
    {
        hitsLeft -= 1;
        GetComponent<Renderer>().material.color = Color.gray;
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