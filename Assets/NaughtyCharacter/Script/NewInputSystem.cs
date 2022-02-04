using System;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NaughtyCharacter.Script
{
    public sealed class NewInputSystem : MonoBehaviour, IEventHandler, IEventSubscriber
    {
        private Vector2 axisRot;
        private bool _jumpInput;
        private bool GetJumpInput()
        {
            return _jumpInput;
        }
        
        private PlayerInput _inputActions;
        private event PlayerEventDelegates.SetMovementInput SetMovementInput;
        private event PlayerEventDelegates.GetDirection GetDirection;
        private event PlayerEventDelegates.SetCameraInput SetCameraInput;
        
        private void OnEnable()
        {
            _inputActions ??= new PlayerInput();
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void Inputs()
        {
           var dir = _inputActions.Player.Movement.ReadValue<Vector2>();
           GetDirection?.Invoke(dir);

           _jumpInput = (_inputActions.Player.Jump.phase == InputActionPhase.Canceled);
            
            axisRot = _inputActions.Camera.Delta.ReadValue<Vector2>();
            SetCameraInput?.Invoke(axisRot);
        }

        public void Update()
        {
            Inputs();
        }
        public void InvokeEvents()
        {
        
        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref SetMovementInput, subscribers);
            EventExtensions.Subscribe(ref GetDirection, subscribers);
            EventExtensions.Subscribe(ref SetCameraInput, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref SetMovementInput, unsubscribers);
            EventExtensions.Unsubscribe(ref GetDirection, unsubscribers);
            EventExtensions.Unsubscribe(ref SetCameraInput, unsubscribers);
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.GETJumpInput) GetJumpInput
            };
        }
    }
}
