using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MinigameManager : MonoBehaviour
{
    public event EventHandler OnMinigameStart;
    public event EventHandler OnMinigameStop;

    public event Action OnFishCaught;
    public event Action OnFishLost;

    public static MinigameManager instance;
    public int bossDifficultyModifier = 0;
    [SerializeField] private SwitchBait switchBait;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject minigameUI;

    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI answerText;

    private string answer = "AWDS";

    private string text = "";
    private int currFishDifficulty = 1;
    private Fish currBaitPower;
    private int currbait = 1;
    private string currAnswer;
    private int currIndex = 0;
    private bool isFishing = false;

    [SerializeField] private float QTETime;
    private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        minigameUI.SetActive(false);

    }

    private void Update()
    {
        //Ini yang bikin shop jadi bisa jalan
        if (timer < 0)
        {
            timer = 0;
            StopFishing();
            Debug.Log("STOP");
        }


        inputText.text = text;
        timerText.text = timer.ToString();

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    ShopManager.instance.OpenShop();
        //}


        if (isFishing)
        {
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.A))
            {
                AddInput("A");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                AddInput("W");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                AddInput("D");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                AddInput("S");
            }
            if (text.Length == currAnswer.Length)
            {
                Debug.Log("Fish Caught");
                OnFishCaught?.Invoke();
                ScoreManager.instance.IncreaseLevelScore(40);
                StopFishing();
            }

        }

    }

    private void AddInput(string _input)
    {
        text += _input;
        CheckInput();
    }

    private void CheckInput()
    {
        Debug.Log(text.Length);
        if (text[currIndex] == currAnswer[currIndex])
        {
            Debug.Log("Valid");
            currIndex++;
        }else
        {
            Debug.Log("Wrong");
            OnFishLost?.Invoke();
            StopFishing();
        }
    }

    private void ResetText()
    {
        currIndex = 0;
        text = "";
    }

    public void AssignDifficulty(int _difficulty)
    {
        currAnswer = "";
        if(_difficulty <= 0)
        {
            //easy prompt
            for(int i = 0; i < 3 + bossDifficultyModifier; i++)
            {
                //currAnswer += UnityEngine.Random.Range(1, 4);
                currAnswer += answer[UnityEngine.Random.Range(1, answer.Length)];
                QTETime = 3;
            }


        }else if(_difficulty == 1)
        {
            //medium prompt
            for (int i = 0; i < 5 + bossDifficultyModifier; i++)
            {
                //currAnswer += UnityEngine.Random.Range(1, 4);
                currAnswer += answer[UnityEngine.Random.Range(1, answer.Length)];
                QTETime = 3;
            }


        }
        else if(_difficulty == 2)
        {
            //hard prompt
            for (int i = 0; i < 7 + bossDifficultyModifier; i++)
            {
                //currAnswer += UnityEngine.Random.Range(1, 4);
                currAnswer += answer[UnityEngine.Random.Range(1, answer.Length)];
                QTETime = 3;
            }

        }
        answerText.text = currAnswer;
        Debug.Log("Difficulty Assigned: " + currAnswer);
    }

    public void StartFishing()
    {
        gameplayUI.SetActive(false);
        minigameUI.SetActive(true);
        isFishing = true;
        GetBait();
        AssignDifficulty(currFishDifficulty-currbait);
        timer = QTETime;
        playerCam.fieldOfView = 30f;

        OnMinigameStart?.Invoke(this,EventArgs.Empty);
    }

    public void GetFishPower(int fishPower)
    {
        currFishDifficulty = fishPower;
        //Debug.Log("Fish Power: " + currFishDifficulty);
    }

    private void StopFishing()
    {
        gameplayUI.SetActive(true);
        minigameUI.SetActive(false);
        ResetText();
        isFishing = false;
        playerCam.fieldOfView = 60f;


        OnMinigameStop?.Invoke(this,EventArgs.Empty);
    }

    private void GetBait()
    {
        switchBait.currBait = currbait;
        //currBaitPower.fishPower = switchBait.currBait;
        Debug.Log(currBaitPower);
    }
}
