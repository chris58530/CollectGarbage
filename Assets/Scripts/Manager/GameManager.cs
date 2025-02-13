using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Tools;



public class GameManager : Singleton<GameManager>
{
    GameState gameState;

    PowerSystem powerSystem;
    TimeSystem timeSystem;
    TravelMapSystem travelMapSystem;
    ResteruantSystem resteruantSystem;
    PlayerControlSystem playerControlSystem;
    [SerializeField] private GameObject player;
    protected override void Awake()
    {
        base.Awake();
        powerSystem = GetComponentInChildren<PowerSystem>();
        timeSystem = GetComponentInChildren<TimeSystem>();
        travelMapSystem = GetComponentInChildren<TravelMapSystem>();
        resteruantSystem = GetComponentInChildren<ResteruantSystem>();
        playerControlSystem = GetComponentInChildren<PlayerControlSystem>();
    }
    void Start()
    {
        ChangeGameState(GameState.Init);
        playerControlSystem.ChangePlayControlState(PlayControlState.OutCar);
    }


    public void ChangeGameState(GameState state)
    {
        // if (gameState == state) return; // 避免重複切換到state
        gameState = state;
        Debug.Log($"GameManager : change game state to <{state.ToString()}>");

        switch (gameState)
        {
            case GameState.Init:
                travelMapSystem.InitSystem();
                timeSystem.InitSystem();
                powerSystem.InitSystem();
                break;
            case GameState.DayStart: //call by TravelMapSystem
                timeSystem.StartSystem();

                break;
            case GameState.SunRise:
                powerSystem.StartSolarPower();
                ChangeGameState(GameState.Playing);
                break;
            case GameState.Playing:

                break;
            case GameState.SunDown:
                powerSystem.EndSolarPower();
                resteruantSystem.InitSystem();
                break;
            case GameState.ResteruantOpen:
                resteruantSystem.OpenResteruant();

                break;
            case GameState.ResteruantClose:
                resteruantSystem.CloseResteraunt();

                ChangeGameState(GameState.DayEnd);
                break;
            case GameState.DayEnd:
                timeSystem.CloseSystem();
                resteruantSystem.ShutDownSystem();
                break;

        }
    }
}
