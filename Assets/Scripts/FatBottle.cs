using UnityEngine;

public class FatBottle : BaseBottle
{
    public int hitsLeft = 2;
    public override bool Hit()
    {
        hitsLeft -= 1;
        GetComponent<Renderer>().material.color = Color.yellow;
        return hitsLeft <= 0;
    }

    public override void End()
    {
        
    }
}