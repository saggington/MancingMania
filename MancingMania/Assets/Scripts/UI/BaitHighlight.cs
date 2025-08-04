using UnityEngine;

public class BaitHighlight : MonoBehaviour
{
    [SerializeField] private GameObject baitHighlight;

    [SerializeField] private int currBait;
    private SwitchBait switchBait;

    private void Awake()
    {
        switchBait = GameObject.FindGameObjectWithTag("Player").GetComponent<SwitchBait>();
    }

    private void Start()
    {
        baitHighlight.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(switchBait != null)
        {
            if(switchBait.currBait == currBait)
            {
                baitHighlight.SetActive(true);
            }
            else
            {
                baitHighlight.SetActive(false);
            }
        }
    }
}
