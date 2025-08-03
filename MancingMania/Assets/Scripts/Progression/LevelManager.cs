using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelStart;
    public event Action OnLevelEnd;

    [SerializeField] private TextMeshProUGUI timerText;
    private Coroutine timeRoutine;

    public static LevelManager instance;

    public int levelCount = 1;
    public float remainingTime = 120;

    private IEnumerator StartTimer()
    {
        OnLevelStart?.Invoke();

        remainingTime = 120; 

        remainingTime -= 1;
        timerText.text = remainingTime.ToString();

        yield return new WaitForSeconds(1);

        if(remainingTime <= 0)
        {
            OnLevelEnd?.Invoke();
        }
    }

    public void StartLevel()
    {
        timeRoutine = StartCoroutine(StartTimer());
    }

    public void EndLevel()
    {
        if (timeRoutine != null)
        {
            StopCoroutine(timeRoutine);
            timeRoutine = null;
        }
        OnLevelEnd?.Invoke();
    }


}
