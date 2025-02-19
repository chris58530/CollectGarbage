using System;
using UniRx;
using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Attack3,

        Roll,

    }

    public enum SuperState
    {
        Normal,
        Hammer,
    }

    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerInput _input;
        private PlayerController _controller;


        private StateMachine<SuperState, string> _fsm;
        private StateMachine<SuperState, PlayerState, string> _normalState;
        private StateMachine<SuperState, PlayerState, string> _hammerState;

        [SerializeField] private Animator animator;


        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _controller = GetComponent<PlayerController>();

        }

        private void Start()
        {
            NormalState();

            //=========================================================================
            //Initialize fsm
            _fsm = new StateMachine<SuperState, string>();



            //_fsm.AddTwoWayTransition(SuperState.Normal, SuperState.NoSword,
            //transitionon => !_attackSystem.hasSword);


            // _fsm.AddTriggerTransition("Award", new Transition<SuperState>(SuperState.Weak, SuperState.Normal));
            // _fsm.AddTriggerTransition("NoSword", new Transition<SuperState>(SuperState.NoSword, SuperState.Weak));
            _fsm.Init();
        }

        private void Update()
        {
            _fsm.OnLogic();
        }

        private void NormalState()
        {
            // if (isHammer) return;

            _normalState = new StateMachine<SuperState, PlayerState, string>();
            _normalState.AddState(
                PlayerState.Idle, new Idle(
                    _input, _controller, animator, false));


            _normalState.AddState(
                PlayerState.Walk, new Walk(
                    _input, _controller, animator, false));
            _normalState.AddState(
                PlayerState.Roll, new Roll(
                    _input, _controller, animator, false));


            _normalState.AddState(
                PlayerState.Attack3, new Attack3(
                    _input, _controller, animator, true));






            //Idle
            _normalState.AddTwoWayTransition(PlayerState.Idle, PlayerState.Walk,
                transition => _input.Move);

            _normalState.AddTransition(PlayerState.Idle, PlayerState.Roll,
                transition => _input.IsPressedRoll );

            _normalState.AddTransition(PlayerState.Idle, PlayerState.Attack3,
                transition => _input.IsPressedAttack);




            //Walk
            _normalState.AddTransition(PlayerState.Walk, PlayerState.Roll,
                transition => _input.IsPressedRoll && !_controller.blockRoll);


            _normalState.AddTransition(PlayerState.Roll, PlayerState.Idle,
                transition => _controller.finsihRoll);





            _normalState.AddTransition(PlayerState.Walk, PlayerState.Attack3,
                transition => _input.IsPressedAttack);



        }


    }
}