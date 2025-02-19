using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventController : MonoBehaviour
{
    public UnityEvent[] animationEvent;
    public void AnimationEvent(int num){
        if (num >= 0 && num < animationEvent.Length)
        {
            animationEvent[num]?.Invoke();
        }
    }
}
