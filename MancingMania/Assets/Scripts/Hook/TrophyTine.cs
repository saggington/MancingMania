using UnityEngine;

public class TrophyTine : HookBase
{
    public override string hookName => "Trophy Tine";

    public override float HookEffect(fish fishe)
    {
        if (fishe.fishPower == 3)
        {
            return 2f;
        }
        return 1f; 
    }
}
