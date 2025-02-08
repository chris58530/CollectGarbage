using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Tools;
using System.Data;

public class MapSystem : Singleton<MapSystem>, ISystem
{
    public Map currentMap;  // 當前地圖區塊
    public Map previousMap; // 上一個區塊
    public Map nextMap;     // 下一個區塊

    public void InitSystem()
    {
    }
    public void ShutDownSystem()
    {
    }
    private void InitMap()
    {

    }
    public void LoadNextMap(Map newMapPrefab)
    {
        Destroy(previousMap); // 移除舊的地圖
        previousMap = currentMap;
        currentMap = Instantiate(newMapPrefab, Vector3.zero, Quaternion.identity);
    }

    public void LoadPreviousMap(Map newMapPrefab)
    {
        Destroy(nextMap); // 移除舊的地圖
        nextMap = currentMap;
        currentMap = Instantiate(newMapPrefab, Vector3.zero, Quaternion.identity);
    }


}
