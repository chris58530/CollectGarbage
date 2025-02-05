using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 單例模式

    public TMP_Text inventoryText; // 連結 UI 文字顯示
    private Dictionary<string, int> inventory = new Dictionary<string, int>(); // 存儲物品

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void AddItem(string itemType, int amount)
    {
        if (inventory.ContainsKey(itemType))
        {
            inventory[itemType] += amount; // 更新數量
        }
        else
        {
            inventory[itemType] = amount; // 新增物品
        }

        UpdateInventoryUI(); // 更新 UI
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = "Inventory:\n";
        foreach (var item in inventory)
        {
            inventoryText.text += $"{item.Key}: {item.Value}\n";
        }
    }
}
