using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private MinigameManager minigameManager;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private SwitchBait switchBait;
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {

        if (Physics.Raycast(playerCamera.transform.position, transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(playerCamera.transform.position, transform.forward * 10, Color.red);
            //Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Fish") && Input.GetKeyDown(KeyCode.E))
            {
                if (switchBait.currBait == 1)
                {
                    if (switchBait.weakBaitAmount > 0)
                    {
                        switchBait.weakBaitAmount -= 1;
                        Debug.Log("StartFishing");
                        minigameManager.StartFishing();
                    }
                }
                if (switchBait.currBait == 2)
                {
                    if (switchBait.MediumBaitAmount > 0)
                    {
                        switchBait.MediumBaitAmount -= 1;
                        Debug.Log("StartFishing");
                        minigameManager.StartFishing();
                    }
                }
                if (switchBait.currBait == 3)
                {
                    if (switchBait.StrongBaitAmount > 0)
                    {
                        switchBait.StrongBaitAmount -= 1;
                        Debug.Log("StartFishing");
                        minigameManager.StartFishing();
                    }
                }
                else
                {
                    Debug.Log("Not enough bait");
                }


            }
            else if (hit.collider.gameObject.name == "Shop" && Input.GetKeyDown(KeyCode.E))
            {
                shopManager.OpenShop();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopManager.CloseShop();
        }

    }
}
