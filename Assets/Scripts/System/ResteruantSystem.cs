using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResteruantSystem : MonoBehaviour, ISystem
{
    private bool allowOpen;

    public void InitSystem()
    {
        allowOpen = true;
    }

    public void OpenResteruant()
    {

    }

    public void ShutDownSystem()
    {
        allowOpen = false;
    }
}
