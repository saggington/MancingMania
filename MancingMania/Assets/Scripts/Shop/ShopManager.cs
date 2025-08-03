using System;
using UnityEngine;
using UnityEngine.UI;

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

    public float money;
    private void Awake()
    {
        instance = this;
    }
    public void OpenShop()
    {
        ShopUI.SetActive(true);
        OnShopOpen?.Invoke(this, EventArgs.Empty);
    }
    public void CloseShop()
    {
        ShopUI.SetActive(false);
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
    }

    public void BuyHook()
    {

    }
}
