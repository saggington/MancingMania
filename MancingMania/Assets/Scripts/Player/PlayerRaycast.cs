using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private MinigameManager minigameManager;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
            //Debug.Log(hit.collider.gameObject.name);

            if(hit.collider.gameObject.name == "Fish" && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("StartFishing");
                minigameManager.StartFishing();
            }
        }

    }
}
