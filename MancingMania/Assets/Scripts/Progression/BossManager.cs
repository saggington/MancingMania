using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void ChooseBoss()
    {
        int bossIndex = Random.Range(0, 1);
        
        switch(bossIndex)
        {
            case 0:
                LevelManager.instance.bossTimeModifier = 40;
                break;
            case 1:
                
                break;
            default:
                Debug.LogError("Invalid boss index chosen");
                break;
        }
    }
}
