using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public List<fish> fish_list = new List<fish>();


}
[System.Serializable]
public class fish : MonoBehaviour
{ 
    public string name;
    public int fishPower;
    public float score;
    public GameObject fishObject;
}
