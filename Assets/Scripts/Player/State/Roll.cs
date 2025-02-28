using System;
using _.Scripts.Tools;
using TMPro;
using UniRx;
using UnityEngine;
using UnityHFSM;

namespace _.Scripts.Player.State
{
    public class Roll : StateBase<PlayerState>
    {
        private readonly PlayerInput _input;

        private readonly PlayerController _controller;
        private Timer _timer;
        private readonly Animator _animator;

        public Roll(PlayerInput playerInput,
            PlayerController controller,
            Animator animator,
            bool needsExitTime, bool isGhostState = false) : base(
            needsExitTime, isGhostState)
        {
            _input = playerInput;
            _controller = controller;
            _animator = animator;
        }

        public override void OnEnter()
        {
            _timer = new Timer();

            _animator.Play(Animator.StringToHash("Roll"));
            // _animator.Play(Animator.StringToHash("Dash_1"));

            _controller.Roll();
            // _attackSystem.finishAttack = false;
            // _attackSystem. finsihFail = true;
            // _attackSystem._failTimer?.Dispose();
            // // _attackSystem.Fail();

            if (_input.Move)
                _controller.FaceInputDireaction(_input);
        }

        public override void OnLogic()
        {
            if (_timer.Elapsed > _controller.rollTime - 0.005f)
            {
                // _animator.CrossFade(Animator.StringToHash("Roll_to_walk"),0);
            }
            else if (_timer.Elapsed > _controller.rollTime)
            {
                fsm.StateCanExit();
            }

            _controller.Fall();
        }

        public override void OnExit()
        {
            // _attackSystem.attackCount = 0;
            // _animator.Play("Q1ToIdle");
         

 
        }
    }
}