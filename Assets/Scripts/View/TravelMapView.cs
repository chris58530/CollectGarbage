using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TravelMapView : MonoBehaviour
{
    [SerializeField] private GameObject viewObject;
    [SerializeField] private TMP_Text powerAmountText;
    [SerializeField] private TMP_Text todayNewsText;
    [SerializeField]private TravelMapSystem system;

    public void InitView(TravelMapSystem travelMap)
    {
        system = travelMap;
    }
    public void Show(bool isShow)
    {
        viewObject.gameObject.SetActive(isShow);
    }

    public void CountinueButton()
    {
       system.onInitReady?.Invoke();

    }
}
