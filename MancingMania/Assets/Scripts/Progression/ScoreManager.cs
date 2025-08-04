using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float permanentScore;
    public float levelScore;

    [SerializeField] private LevelManager levelManager;

    private float scaling = 0;
    private float scoreCap = 120;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //LevelManager.instance.OnLevelStart += ResetLevelScore;
        //LevelManager.instance.OnLevelEnd += CheckScore;
        //LevelManager.instance.OnBossLevelEnd += IncreaseScaling;
    }

    private void OnEnable()
    {
        levelManager.OnLevelStart += ResetLevelScore;
        levelManager.OnLevelEnd += CheckScore;
        levelManager.OnBossLevelEnd += IncreaseScaling;
    }

    private void OnDisable()
    {
        levelManager.OnLevelStart -= ResetLevelScore;
        levelManager.OnLevelEnd -= CheckScore;
        levelManager.OnBossLevelEnd -= IncreaseScaling;
    }

    private void ResetLevelScore()
    {
        levelScore = 0;
    }

    private void CheckScore()
    {
        if (levelScore >= scoreCap)
        {
            //convert to money
            ShopManager.instance.money += levelScore + LevelManager.instance.remainingTime;
            IncreaseScoreCap();

            //open shop - win
            ShopManager.instance.OpenShop();

        }
        else
        {
            //return to main menu - lose
        }
    }

    public void IncreaseLevelScore(float amount, float mult, float addition)
    {
       levelScore += (amount * mult) + addition;
    }

    private void IncreaseScoreCap()
    {
        scoreCap += scaling;
    }

    private void IncreaseScaling()
    {
        scaling =+ 10;
    }


}
