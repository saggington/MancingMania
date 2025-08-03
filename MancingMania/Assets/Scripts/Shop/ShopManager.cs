using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public event EventHandler OnShopOpen;
    public event EventHandler OnShopClose;
    public static ShopManager instance;

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
        if (money > 10)
        {
            money -= 10;
            switchBait.AddWeakBait();
        }
        else
            Debug.Log("Not enough money");

    }
    public void BuyMediumBait()
    {
        if (money > 50)
        {
            money -= 50;
            switchBait.AddMediumBait();
        }
        else
            Debug.Log("Not enough money");
    }
    public void BuyStrongBait()
    {
        if (money > 100)
        {
            money -= 100;
            switchBait.AddStrongBait();
        }
        else
            Debug.Log("Not enough money");
    }
}
