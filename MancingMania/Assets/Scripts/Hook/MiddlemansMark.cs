using UnityEngine;

public class MiddlemansMark : HookBase
{
    public override string hookName => "Middleman's Mark";

    private fish previousFish;

    public override float HookEffect(fish fishe)
    {
        if (fishe.fishPower == 2)
        {
            if (previousFish.fishPower == 1 || previousFish.fishPower == 3)
            {
                previousFish = fishe;
                return 2f; 
            }
        }

        previousFish = fishe;
        return 1f;
    }
}
