using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelStart;
    public event Action OnLevelEnd;

    [SerializeField] private TextMeshProUGUI timerText;

    private float remainingTime = 120;

    public static LevelManager instance;

    private IEnumerator StartTimer()
    {
        remainingTime = 120; 

        remainingTime -= 1;
        yield return new WaitForSeconds(1);

        if(remainingTime <= 0)
        {
            OnLevelEnd?.Invoke();
        }
    }

    public void StartLevel()
    {
        StartCoroutine(StartTimer());
    }
}
