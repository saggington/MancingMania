using UnityEngine;

public class LuckyLure : HookBase
{
    public override string hookName => "Lucky Lure";

    public override float HookEffect(fish fishe)
    {
        if(fishe.fishPower == 1)
        {
            return 2f;
        }
        return 1f;
    }
}
