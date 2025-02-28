using _.Scripts.Tools;
using UnityEngine;
using UnityHFSM;

namespace @_.Scripts.Player.State
{
    public class Idle : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerInput _input;
        private readonly PlayerController _controller;


        public Idle(PlayerInput playerInput,
            PlayerController playerController, Animator animator,
          
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime,
            isGhostState)
        {
            _input = playerInput;
            _controller = playerController;
            _animator = animator;
        }

        public override void OnEnter()
        {
            //debug


            // _animator.Play("Q1ToIdle");

            _animator.CrossFade(Animator.StringToHash("Idle"), 0.2f);
        }

        public override void OnLogic()
        {
            _controller.Fall();
         
        }

        public override void OnExit()
        {
        }
    }
}