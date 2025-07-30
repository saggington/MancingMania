using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public List<fish> fish_list = new List<fish>();


}
[System.Serializable]
public class fish
{
    public string name;
    public int fishPower;
    public int score;
}
