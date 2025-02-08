using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private CloneMapTrigger[] trigger;
    public void SetTriggerOn(bool on)
    {
        foreach (var cloneMapTrigger in trigger)
        {
            if (on)
                cloneMapTrigger.Show();
            else
                cloneMapTrigger.Hide();
        }
    }
}
[System.Serializable]
public class MapData
{
    public string mapID;        
    public GameObject prefab;   
    public string previousMapID; 
    public string nextMapID;   
}
