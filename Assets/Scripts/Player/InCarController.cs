using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerInCarController : Controller
{
    protected override void Update()
    {
        base.Update();
        ExitCar();
    }
    private void ExitCar()
    {
        if (!Input.GetKeyDown(KeyCode.Q)) return;

        PlayerControlSystem.Instance.RequestFlipControl();
    }
}