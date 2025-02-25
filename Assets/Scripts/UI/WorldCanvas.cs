using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class WorldCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private IDisposable timer;
    void Start()
    {
        SetText("");
    }
    public void SetText(string value)
    {
        timer?.Dispose();
        text.text = value;
    }
    public void SetText(string value, float time)
    {
        timer?.Dispose();
        text.text = value;
        timer = Observable.EveryUpdate().Delay(TimeSpan.FromSeconds(time)).Subscribe(_ => text.text = "");
    }
}
