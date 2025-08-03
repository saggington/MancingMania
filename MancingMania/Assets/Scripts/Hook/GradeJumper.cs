using UnityEngine;

public class GradeJumper : HookBase
{
    public override string hookName => "Grade Jumper";

    private fish previousFish;
    public override float HookEffect(fish fishe)
    {
        if (previousFish == null)
        {
            previousFish = fishe;
            return 1f; 
        }
        if (fishe.fishPower == previousFish.fishPower + 1 || fishe.fishPower == previousFish.fishPower - 1)
        {
            previousFish = fishe;
            return 3f;  
        }
        previousFish = fishe;
        return 1f; 
    }
}
