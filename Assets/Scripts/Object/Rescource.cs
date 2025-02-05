using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resourceType; // 資源類型（例如 "Wood" 或 "Stone"）
    public int resourceAmount = 1; // 資源數量

    public void Collect()
    {
        Debug.Log($"Collected {resourceAmount} {resourceType}");
        InventoryManager.Instance.AddItem(resourceType, resourceAmount); // 更新背包
        Destroy(gameObject); // 拾取後刪除物件
    }
}
