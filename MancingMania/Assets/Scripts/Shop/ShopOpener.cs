using UnityEngine;

public class ShopOpener : MonoBehaviour
{
    [SerializeField] private ShopManager shopManager;

    private void start()
    {
        shopManager = ShopManager.instance;

        if(shopManager != null)
        {
            shopManager.OpenShop();
        }
    }
}
