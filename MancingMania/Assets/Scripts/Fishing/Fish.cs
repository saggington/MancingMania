using UnityEngine;

public class Fish : fish
{
    private FishManager fishManager;

    private void Awake()
    {
        fishManager = GameObject.FindGameObjectWithTag("FishManager").GetComponent<FishManager>();
    }

    void OnMouseDown()
    {
        MinigameManager minigameManager = MinigameManager.instance;

        if(minigameManager != null)
        {
            minigameManager.GetFishPower(fishPower);
            minigameManager.StartFishing();
        }
    }

}
