using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventTable 
{
     // 事件回調
    public static Action OnDayStart;
    public static Action OnNightStart;
    public static Action OnSunRise;
    public static Action OnSunDown;
}
