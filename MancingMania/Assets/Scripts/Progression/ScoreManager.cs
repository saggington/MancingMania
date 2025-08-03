using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float permanentScore;
    public float levelScore;

    private float scaling = 0;
    private float scoreCap = 120;

    private void OnEnable()
    {
        LevelManager.instance.OnLevelStart += ResetLevelScore;
        LevelManager.instance.OnLevelEnd += CheckScore;
        LevelManager.instance.OnBossLevelEnd += IncreaseScaling;
    }

    private void OnDisable()
    {
        LevelManager.instance.OnLevelStart -= ResetLevelScore;
        LevelManager.instance.OnLevelEnd -= CheckScore;
        LevelManager.instance.OnBossLevelEnd -= IncreaseScaling;
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

        }
        else
        {
            //return to main menu - lose
        }
    }

    public void IncreaseLevelScore(float amount)
    {
       levelScore += amount;
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
