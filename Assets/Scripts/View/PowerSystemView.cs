using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerSystemView : MonoBehaviour, IView<PowerSystem>
{
    [SerializeField] private GameObject viewObject;
    [SerializeField] private TMP_Text powerAmountText;
    [SerializeField]private PowerSystem system;

    public void UpdatePower(float power)
    {
        powerAmountText.text = power.ToString();
    }
    public void InitView(PowerSystem powerSystem)
    {
        system = powerSystem;
    }
    public void Show(bool isShow)
    {
        viewObject.gameObject.SetActive(isShow);
    }
}
