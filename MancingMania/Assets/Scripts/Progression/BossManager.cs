using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        instance = this;
        //LevelManager.instance.OnBossLevelStart += ChooseBoss;
        //LevelManager.instance.OnBossLevelEnd += ClearBoss;
    }

    private void OnEnable()
    {
        levelManager.OnBossLevelStart += ChooseBoss;
        levelManager.OnBossLevelEnd += ClearBoss;
    }

    private void OnDisable()
    {
        levelManager.OnBossLevelStart -= ChooseBoss;
        levelManager.OnBossLevelEnd -= ClearBoss;
    }

    private void ChooseBoss()
    {
        Debug.Log("Boss level started");

        int bossIndex = Random.Range(0, 2);
        
        switch(bossIndex)
        {
            case 0:
                LevelManager.instance.bossTimeModifier = -40;
                break;
            case 1:
                MinigameManager.instance.bossDifficultyModifier = 2;
                break;
        }
    }

    private void ClearBoss()
    {
        LevelManager.instance.bossTimeModifier = 0;
        MinigameManager.instance.bossDifficultyModifier = 0;
    }
}
