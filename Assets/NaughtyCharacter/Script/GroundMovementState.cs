using System;
using CorePlugin.Extensions;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class GroundMovementState : Controller<CharacterController>
    {
        private readonly float _gravity = 20.0f;
        private readonly float _groundedGravity = 5.0f; 
        private readonly float _maxFallSpeed = 40.0f; 

        private float _horizontalSpeed = 5;
        private float _verticalSpeed=5;

        private CharacterController _characterController;
        private PlayerEventDelegates.GETIsGrounded _isGrounded;


        public override void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
        }
        public override void Updates(Vector3 dir, float deltaTime)
        {
            var movement = (_characterController.transform.forward * dir.y + _characterController.transform.right * dir.x).normalized;
            _characterController.Move(_horizontalSpeed * movement * deltaTime);
        }
         private void UpdateVerticalSpeed(float deltaTime)
         {
             var IsGrounded = _isGrounded.Invoke();
             if (IsGrounded)
             {
                 _verticalSpeed = -_groundedGravity;

                 if (!_jumpInput) return;
                 _verticalSpeed = JumpSpeed;
             }
             else
             {
                 if (!_jumpInput && _verticalSpeed > 0.0f)
                 {
                     _verticalSpeed = Mathf.MoveTowards(_verticalSpeed, -_maxFallSpeed, JumpAbortSpeed * deltaTime);
                 }
                 else if (_justWalkedOffALedge)
                 {
                     _verticalSpeed = 0.0f;
                 }
 
                 _verticalSpeed = Mathf.MoveTowards(_verticalSpeed, -_maxFallSpeed, _gravity * deltaTime);
             }
         }


        public override void Exit()
        {

        }
        public override void InvokeEvents()
        {

        }
        public override void Subscribe(params Delegate[] subscribers)
        {
        }
        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
        }
    }
}
