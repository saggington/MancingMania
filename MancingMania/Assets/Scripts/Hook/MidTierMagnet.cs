using UnityEngine;

public class MidTierMagnet : HookBase
{
    public override string hookName = "Mid-Tier Magnet";

    public override float HookEffect(fish fishe)
    {
        if (fishe.fishPower == 2)
        {
            return 2f;
        }
        return 1f;
    }
}
