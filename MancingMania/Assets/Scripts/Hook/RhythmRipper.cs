using UnityEngine;

public class RhythmRipper : HookBase
{
    public override string hookName => "Rhythm Ripper";

    private fish previousFish;

    public override float HookEffect(fish fishe)
    {
        int rythmCount = 0;
        previousFish = fishe;

        if(previousFish != null)
        {
            int downbeat = 0;
            int upbeat = 0;

            if (previousFish.fishPower - fishe.fishPower == 1 || previousFish.fishPower - fishe.fishPower == -1)
            {
                if(previousFish.fishPower > fishe.fishPower || previousFish.fishPower < fishe.fishPower)
                {
                    //BINGUNG
                }
            }
        }

        return 1f; // Normal catch effect
    }
}
