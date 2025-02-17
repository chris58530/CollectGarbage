using UnityEngine;
using UnityHFSM;
using System;
using _.Scripts.Player.Props;
using TMPro;
using UniRx;

namespace _.Scripts.Player.State
{
    public class Walk : StateBase<PlayerState>
    {
        private readonly PlayerInput _input;
        private readonly PlayerController _controller;
        private readonly Animator _animator;

        public Walk(
            PlayerInput playerInput,
            PlayerController controller, Animator animator,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _input = playerInput;
            _controller = controller;
            _animator = animator;
        }

        public override void OnEnter()
        {
            //debug
         
            _animator.CrossFade(Animator.StringToHash("Walk"), 0.2f);
         
        }

        public override void OnLogic()
        {
            if (_input.Move)
                _controller.Move(_input);


            _controller.Fall();
        }

        public override void OnExit()
        {
           


        }
    }
}