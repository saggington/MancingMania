using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public event EventHandler OnShopOpen;
    public event EventHandler OnShopClose;
    public static ShopManager instance;

    private int weakBCost = 1;
    private int mediumBCost = 2;
    private int strongBCost = 3;

    private int weakCounter = 0;
    private int mediumCounter = 0;
    private int strongCounter = 0;

    [SerializeField] private Button hookBuyButton;
    [SerializeField] private SwitchBait switchBait;
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI weakBaitText;
    [SerializeField] private TextMeshProUGUI mediumBaitText;
    [SerializeField] private TextMeshProUGUI strongBaitText;

    public float money;
    private void Awake()
    {
        instance = this;
    }
    public void OpenShop()
    {
        ShopUI.SetActive(true);
        GameplayUI.SetActive(false);
        coinText.text = "Coins:" + money.ToString();
        OnShopOpen?.Invoke(this, EventArgs.Empty);
    }
    public void CloseShop()
    {
        ShopUI.SetActive(false);
        GameplayUI.SetActive(true);
        OnShopClose?.Invoke(this, EventArgs.Empty);
    }

    public void BuyWeakBait()
    {
        if(weakCounter == 6)
        {
            weakBCost = 4;
        }
        if(weakCounter == 12)
        {
            weakBCost = 10;
        }
        if (money > weakBCost)
        {
            money -= weakBCost;
            weakCounter += 1;
            switchBait.AddWeakBait();
        }
        else
            Debug.Log("Not enough money");

        weakBaitText.text = "Price: " + weakCounter.ToString();

    }
    public void BuyMediumBait()
    {
        if (mediumCounter == 4)
        {
            mediumBCost = 8;
        }
        if (mediumCounter == 8)
        {
            mediumBCost = 20;
        }
        if (money > mediumBCost)
        {
            money -= mediumBCost;
            mediumCounter += 1;
            switchBait.AddMediumBait();
        }
        else
            Debug.Log("Not enough money");

        mediumBaitText.text = "Price: " + mediumBCost.ToString();
    }
    public void BuyStrongBait()
    {
        if(strongCounter == 2)
        {
            strongBCost = 12;
        }
        if (strongCounter == 4)
        {
            strongBCost = 30;
        }
        if (money > strongBCost)
        {
            money -= strongBCost;
            strongCounter += 1;
            switchBait.AddStrongBait();
        }
        else
            Debug.Log("Not enough money");

        strongBaitText.text = "Price: " + strongBCost.ToString();
    }

    public void BuyHook()
    {

    }
}
