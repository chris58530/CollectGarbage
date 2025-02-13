using System.Collections;
using System.Collections.Generic;
using _.Scripts.Tools;
using UnityEngine;

public class PlayerControlSystem : Singleton<PlayerControlSystem>
{
    [SerializeField] private PlayerInCarController playerInCar;
    [SerializeField] private PlayerController player;
    public void ChangePlayControlState(PlayControlState state)
    {
        Proxy.playControlState = state;
    }
    public void RequestFlipControl()
    {

        switch (Proxy.playControlState)
        {
            case PlayControlState.InCar:
                ChangePlayControlState(PlayControlState.OutCar);
                playerInCar.Show();
                player.Hide();
                Debug.Log("incar");
                break;
            case PlayControlState.OutCar:
                ChangePlayControlState(PlayControlState.InCar);
                Debug.Log("outcar");

                playerInCar.Hide();
                player.Show();
                break;
        }
    }
}
