using UnityEngine;
using UnityEngine.UI;

public class CarSystem : MonoBehaviour
{
    public GameObject carUI; // UI 元素
      

   
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        carUI.SetActive(true); // 顯示 UI
    }
}
void OnTriggerExit(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        carUI.SetActive(false); // 隱藏 UI
    }

}}