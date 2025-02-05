using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Tools;



public class PowerSystem : Singleton<PowerSystem>, ISystem
{
    [SerializeField] private PowerSystemView view;
    private float currentPower;
    public float initPower = 0f; // 電力值


    public void InitSystem()
    {
        view = GameObject.FindObjectOfType<PowerSystemView>();
        currentPower = initPower;
        UpdatePower(currentPower);
    }
    public void ShutDownSystem() { }
    void OnEnable()
    {

    }
    /// <summary>
    /// Other object check  CheckPowerLeft than UpdatePower
    /// </summary>
    public bool CheckPowerLeft(float usePower)
    {
        return currentPower >= usePower;
    }
    public void UpdatePower(float amount)
    {
        if (!CheckPowerLeft(amount))
        {
            Debug.Log($"Not enough power left. Current power: {currentPower}, required: {amount}");
            return;//for safe
        }

        currentPower -= amount;
        view.UpdatePower(currentPower);
    }
    public void StartSolarPower()
    {
     
        StartCoroutine(nameof(SolarPower));
    }
    public void EndSolarPower()
    {
        StopCoroutine(nameof(SolarPower));

    }
    IEnumerator SolarPower()
    {
        while (true)
        {
            //未來加入天氣系統在這裡更改累計效率
            currentPower += 1;
            Debug.Log($"currentPower ;  {currentPower}");
            view.UpdatePower(currentPower);
            yield return new WaitForSeconds(1f);
        }
    }
}
