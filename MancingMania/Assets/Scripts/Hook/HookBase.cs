using UnityEngine;

public abstract class HookBase
{
    public string hookName;
    public float hookPrice = 40f;

    public virtual float HookEffect(fish fishe)
    {
        return 1f;
    }


}
