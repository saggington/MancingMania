using UnityEngine;

public abstract class HookBase
{
    public virtual string hookName => "Regular Hook";
    public float hookPrice = 40f;

    public virtual float HookEffect(fish fishe)
    {
        return 1f;
    }


}
