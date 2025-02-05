using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Tools;
using System;
public class TravelMapSystem : Singleton<TravelMapSystem>, ISystem
{
    [SerializeField] private TravelMapView view;

    public Action onInitReady;

    private void OnEnable()
    {
        onInitReady += OnInitReady;
    }

    public void InitSystem()
    {
        view = GameObject.FindObjectOfType<TravelMapView>();
        if (view == null) return;
        view.InitView(this);

        view.Show(true);
    }

    public void DisplayPower(float amount)
    {
        PowerSystem.Instance.UpdatePower(amount);
    }
    public void OnInitReady()
    {
        GameManager.Instance.ChangeGameState(GameState.DayStart);

        view.Show(false);
    }

    public void ShutDownSystem()
    {
    }
}
