using System;
using CorePlugin.Extensions;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class GroundMovementState : Controller<CharacterController>
    {
        [SerializeField] private LayerMask GroundLayers;

        private readonly float _gravity = -1f;
        private readonly float _groundedGravity = 0f;
        private readonly float _maxFallSpeed = 1.0f;
        private readonly float _horizontalSpeed = 5;
        private readonly float _jumpAbortSpeed = 10.0f;
        private readonly float _jumpSpeed = 100.0f;

        private float _verticalSpeed = 5;
        private float _sphereCastRadius = 0.01f;
        private bool _isGrounded = true;
        private bool _justWalkedOffEdge = false;

        private CharacterController _characterController;
        private Transform _transform;
        private PlayerEventDelegates.GETJumpInput GetJumpInput;

        public override void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
            _transform = _characterController.transform;
            _transform.position = new Vector3(25, 1, -25);
            GroundLayers = LayerMask.NameToLayer("Ground");
        }
        public override void Updates(Vector3 dir, float deltaTime)
        {
            var isGrounded = CheckGrounded();
            _justWalkedOffEdge = false;

            if (_isGrounded && !isGrounded && !GetJumpInput.Invoke())
            {
                _justWalkedOffEdge = true;
            }
            _isGrounded = isGrounded;
            UpdateVerticalSpeed(deltaTime);
            var movement = (_transform.forward * dir.y + _transform.right * dir.x).normalized;
            _characterController.Move(_horizontalSpeed * movement * deltaTime);
        }

        private bool CheckGrounded()
        {
            var spherePosition = _transform.position;
            spherePosition.y -= 1;
            Debug.Log(spherePosition);
            var isGrounded = Physics.CheckSphere(spherePosition, _sphereCastRadius, GroundLayers);

            return isGrounded;
        }

        private void UpdateVerticalSpeed(float deltaTime)
        {
            Debug.Log(_isGrounded);
            if (_isGrounded)
            {
                _verticalSpeed = -_groundedGravity * deltaTime;
                if (!GetJumpInput.Invoke()) return;
                _verticalSpeed = _jumpSpeed;
                _isGrounded = false;
            }
            else
            {
                if (!GetJumpInput.Invoke())
                {
                    // This is what causes holding jump to jump higher than tapping jump.
                    _verticalSpeed = Mathf.MoveTowards(_verticalSpeed, -_maxFallSpeed, _jumpAbortSpeed * deltaTime);
                }

                _verticalSpeed = Mathf.MoveTowards(_verticalSpeed, -_maxFallSpeed, _gravity * deltaTime);
            }
            _characterController.Move(_verticalSpeed * Vector3.up);
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
        }
        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref GetJumpInput, unsubscribers);
        }
    }
}
