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
    [SerializeField] private GameObject gameplayUI;
    private Coroutine timeRoutine;

    public static LevelManager instance;

    public int levelCount = 3;
    public float remainingTime;
    public float bossTimeModifier = 0f;
    public bool levelRunning = false;

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
    }

    private void Start()
    {
        timerText.text = remainingTime.ToString();
        StartLevel();
    }

    private void OnEnable()
    {
        OnLevelEnd += IncrementLevel;
        OnLevelEnd += CloseGameplayUI;
        OnLevelStart += OpenGameplayUI;
    }

    private void OnDisable()
    {
        OnLevelEnd -= IncrementLevel;
        OnLevelEnd -= CloseGameplayUI;
        OnLevelStart -= OpenGameplayUI;
    }

    private void CloseGameplayUI()
    {
        gameplayUI.SetActive(false);
    }

    private void OpenGameplayUI()
    {
        gameplayUI.SetActive(true);
    }

    private IEnumerator StartTimer()
    {
        Debug.Log("Timer started");

        for(float i = remainingTime; i >= 0; i--)
        {
            if (remainingTime <= 0 && levelRunning)
            {
                EndLevel();
                yield break;
            }

            remainingTime -= 1;
            timerText.text = remainingTime.ToString();
            //Debug.Log("Remaining time: " + remainingTime);
            yield return new WaitForSeconds(1);
        }
    }

    private void IncrementLevel()
    {
        levelCount += 1;
    }

    public void StartLevel()
    {
        Debug.Log("Level started");
        levelRunning = true;
        //gameplayUI.SetActive(true);

        if (levelCount % 3 == 0)
        {
            Debug.Log("Boss level started");
            OnBossLevelStart?.Invoke();
        }

        remainingTime = 120 + bossTimeModifier;

        OnLevelStart?.Invoke();
        
        timeRoutine = StartCoroutine(StartTimer());
    }

    public void EndLevel()
    {
        //Debug.Log("Level ended");
        gameplayUI?.SetActive(false);
        remainingTime = 0;
        levelRunning = false;

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
