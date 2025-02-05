using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystemView : MonoBehaviour,IView<TimeSystem>
{
    [SerializeField] private TMP_Text currentDayText;
    [SerializeField] private TMP_Text timeDisplayText;
    TimeSystem system;

    public void InitView(TimeSystem timeSystem)
    {
        system = timeSystem;

    }
    public void UpdateTime(int currentHour)
    {
        timeDisplayText.text = $"{currentHour:D2}:00";

    }
    public void UpdateDay(bool isDaytime)
    {
        currentDayText.text = isDaytime ? "Day" : "Night";

    }
}
