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
    protected override void Awake()
    {
        base.Awake();
        powerSystem = GetComponentInChildren<PowerSystem>();
        timeSystem = GetComponentInChildren<TimeSystem>();
        travelMapSystem = GetComponentInChildren<TravelMapSystem>();
        resteruantSystem = GetComponentInChildren<ResteruantSystem>();
    }
    void Start()
    {
        ChangeGameState(GameState.Init);
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

                break;
            case GameState.ResteruantOpen:


                break;
            case GameState.ResteruantClose:
                ChangeGameState(GameState.DayEnd);

                break;
            case GameState.DayEnd:
                timeSystem.CloseSystem();
                break;

        }
    }
}
