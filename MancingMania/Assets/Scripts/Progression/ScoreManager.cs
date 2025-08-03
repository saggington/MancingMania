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
        instance = this;
        LevelManager.instance.OnLevelStart += ResetLevelScore;
        LevelManager.instance.OnLevelEnd += CheckScore;
    }

    private void OnDisable()
    {
        LevelManager.instance.OnLevelStart -= ResetLevelScore;
        LevelManager.instance.OnLevelEnd -= CheckScore;
    }

    private void ResetLevelScore()
    {
        levelScore = 0;
    }

    private void CheckScore()
    {
        if (levelScore >= scoreCap)
        {
            permanentScore += levelScore + LevelManager.instance.remainingTime;
            IncreaseScoreCap();

        }
        else
        {
            //return to main menu
        }
    }

    public void IncreaseScore(float amount)
    {
        score += amount;
    }

    private void IncreaseScoreCap()
    {
        scoreCap += scaling;
    }

    private void IncreaseScaling()
    {
        scaling + 10 * LevelManager.instance.levelCount;
    }


}
