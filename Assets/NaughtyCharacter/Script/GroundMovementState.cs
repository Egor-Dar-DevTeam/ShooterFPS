using System;
using CorePlugin.Extensions;
using UnityEngine;
using Weapons.Scripts;

namespace NaughtyCharacter.Script
{
    [Serializable]
    public class GroundMovementState : Controller<CharacterController>
    {
        private readonly float _gravity = 20f;
        private readonly float _groundedGravity = 1f;
        private readonly float _horizontalSpeed = 5;
        private readonly float _jumpSpeed = 0.6f;

        private float _verticalSpeed = 0;
        private float _sphereCastRadius = 0.1f;
        private bool _isGrounded = false;

        private CharacterController _characterController;
        private Transform _transform;
        private PlayerEventDelegates.GETJumpInput GetJumpInput;
        private PlayerEventDelegates.GETInputShoot GETInputShoot;

        public override void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
            _transform = _characterController.transform;
            _transform.position = new Vector3(25, 1, -25);
        }

        public override void Updates(Vector3 dir, float deltaTime)
        {
            _isGrounded = CheckGrounded();

            UpdateVerticalSpeed(deltaTime);

            var movement = (_transform.forward * dir.y + _transform.right * dir.x).normalized;
            _characterController.Move(_horizontalSpeed * movement * deltaTime);
        }
        
        private bool CheckGrounded()
        {
            var spherePosition = _transform.position;
            spherePosition.y -= 1;
            var isGrounded = Physics.CheckSphere(spherePosition, _sphereCastRadius, 8, QueryTriggerInteraction.Ignore);
            return isGrounded;
        }


        private void UpdateVerticalSpeed(float deltaTime)
        {
            if (_isGrounded)
            {
                _verticalSpeed = -_groundedGravity;
                if (!GetJumpInput.Invoke()) return;
                _verticalSpeed += Mathf.Sqrt(_jumpSpeed * -3.0f * -_gravity);
            }
            else _verticalSpeed += -_gravity * deltaTime;

          _characterController.Move(_verticalSpeed * Vector3.up * deltaTime);
        }


        public override void Exit()
        {
        }

        public override void InvokeEvents()
        {
        }

        public override void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref GetJumpInput, subscribers);
            EventExtensions.Subscribe(ref GETInputShoot, subscribers);
        }

        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref GetJumpInput, unsubscribers);
            EventExtensions.Unsubscribe(ref GETInputShoot, unsubscribers);
        }
    }
}