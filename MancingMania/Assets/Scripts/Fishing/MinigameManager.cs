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
    [SerializeField] private SwitchBait switchBait;
    [SerializeField] private Camera playerCam;

    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI answerText;

    private string text = "";
    private int currFishDifficulty = 1;
    private int currBaitPower;
    private string currAnswer;
    private int currIndex = 0;
    private bool isFishing = false;

    [SerializeField] private float QTETime;
    private float timer;

    private void Awake()
    {
        instance = this;
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


        if(isFishing)
        {
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AddInput("1");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AddInput("2");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AddInput("3");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AddInput("4");
            }
            if (text.Length == currAnswer.Length)
            {
                Debug.Log("Fish Caught");
                OnFishCaught?.Invoke();
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
            for(int i = 0; i < 3; i++)
            {
                currAnswer += UnityEngine.Random.Range(1, 4);
                QTETime = 7;
            }


        }else if(_difficulty == 1)
        {
            //medium prompt
            for (int i = 0; i < 5; i++)
            {
                currAnswer += UnityEngine.Random.Range(1, 4);
                QTETime = 5;
            }


        }
        else if(_difficulty == 2)
        {
            //hard prompt
            for (int i = 0; i < 7; i++)
            {
                currAnswer += UnityEngine.Random.Range(1, 4);
                QTETime = 7;
            }

        }
        answerText.text = currAnswer;
    }

    public void StartFishing()
    {
        isFishing = true;
        GetBait();
        AssignDifficulty(currFishDifficulty-currBaitPower);
        timer = QTETime;
        playerCam.fieldOfView = 30f;

        OnMinigameStart?.Invoke(this,EventArgs.Empty);
    }
    private void StopFishing()
    {
        ResetText();
        isFishing = false;
        playerCam.fieldOfView = 60f;


        OnMinigameStop?.Invoke(this,EventArgs.Empty);
    }

    private void GetBait()
    {
        currBaitPower = switchBait.currBait;
        Debug.Log(currBaitPower);
    }
}
