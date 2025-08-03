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
        weakText.text = weakBaitAmount.ToString();
        mediumText.text = MediumBaitAmount.ToString();
        strongText.text = StrongBaitAmount.ToString();



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
    }
    public void AddMediumBait()
    {
        MediumBaitAmount++;
    }
    public void AddStrongBait()
    {
        StrongBaitAmount++;
    }

}
