using TMPro;
using UnityEngine;

public class SwitchBait : MonoBehaviour
{
    public int currBait;
    public int weakBaitAmount;
    public int MediumBaitAmount;
    public int StrongBaitAmount;

    [SerializeField] private TextMeshProUGUI weakText;
    [SerializeField] private TextMeshProUGUI mediumText;
    [SerializeField] private TextMeshProUGUI strongText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currBait = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currBait = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currBait = 3;
        }
    }
    public void AddWeakBait()
    {
        weakBaitAmount++;
        weakText.text = weakBaitAmount.ToString();
    }
    public void AddMediumBait()
    {
        MediumBaitAmount++;
        mediumText.text = MediumBaitAmount.ToString();
    }
    public void AddStrongBait()
    {
        StrongBaitAmount++;
        strongText.text = StrongBaitAmount.ToString();
    }
    public void UseBait()
    {

    }
}
