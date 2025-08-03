using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelStart;
    public event Action OnLevelEnd;
    public event Action OnBossLevelStart;
    public event Action OnBossLevelEnd;

    [SerializeField] private TextMeshProUGUI timerText;
    private Coroutine timeRoutine;

    public static LevelManager instance;

    public int levelCount = 1;
    public float remainingTime = 120;

    private void OnEnable()
    {
        OnLevelEnd += IncrementLevel;
    }

    private void OnDisable()
    {
        OnLevelEnd -= IncrementLevel;
    }

    private IEnumerator StartTimer()
    {

        remainingTime -= 1;
        timerText.text = remainingTime.ToString();

        if(remainingTime <= 0)
        {
            if (levelCount % 3 == 0)
            {
                OnBossLevelEnd?.Invoke();
            }

            OnLevelEnd?.Invoke();

        }

        yield return new WaitForSeconds(1);
    }

    private void IncrementLevel()
    {
        levelCount += 1;
    }

    public void StartLevel()
    {
        remainingTime = 120;

        OnLevelStart?.Invoke();

        if (levelCount % 3 == 0)
        {
            OnBossLevelStart?.Invoke();
        }
        timeRoutine = StartCoroutine(StartTimer());
    }

    public void EndLevel()
    {
        if (timeRoutine != null)
        {
            StopCoroutine(timeRoutine);
            timeRoutine = null;
        }

        if (levelCount % 3 == 0)
        {
            OnBossLevelEnd?.Invoke();
        }
        OnLevelEnd?.Invoke();
    }


}
