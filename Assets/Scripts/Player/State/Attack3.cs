using _.Scripts.Tools;
using UnityEngine;
using UnityHFSM;

namespace @_.Scripts.Player.State
{
    public class Attack3 : StateBase<PlayerState>
    {
        private Animator _animator;
        private readonly PlayerInput _input;
        private readonly PlayerController _controller;
        private Timer _timer;

        public Attack3(PlayerInput playerInput,
            PlayerController playerController,
            Animator animator,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _input = playerInput;
            _controller = playerController;
            _animator = animator;
        }

        public override void OnEnter()
        {            
          

            _timer = new Timer();
            // _animator.CrossFade(Animator.StringToHash("Q3"), 0.1f);
         

            _animator.Play("Q3");

            // if (_input.Move)
            //     _controller.FaceInputDireaction(_input);
        }

        public override void OnLogic()
        {
          
                fsm.StateCanExit();
        }

        public override void OnExit()
        {
            // _animator.CrossFade(Animator.StringToHash("Idle"), 0.8f);
            // _controller.transform.localEulerAngles = new Vector3(0
            //     , _controller.transform.rotation.y, _controller.transform.rotation.z);
     
        }
    }
}