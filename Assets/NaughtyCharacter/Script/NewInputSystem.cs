using System;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Scripting;

namespace NaughtyCharacter.Script
{
    public sealed class NewInputSystem : MonoBehaviour, IEventHandler, IEventSubscriber
    {

        private Vector2 axisRot;
        private Vector2 dirMovement;
        private bool _jumpInput;
        private bool _shootInput;
        private bool GetJumpInput() => _jumpInput;
        private bool GetShootInput() => _shootInput;

        private PlayerInput _inputActions;
        private InputAction.CallbackContext ContextShoot;
        private event PlayerEventDelegates.SetMovementInput SetMovementInput;
        private event PlayerEventDelegates.GetDirection GetDirection;
        private event PlayerEventDelegates.SetCameraInput SetCameraInput;
        private event PlayerEventDelegates.RechooseeWeapon RechooseeWeapon;
        private event PlayerEventDelegates.Shoot Shoot;
        private event PlayerEventDelegates.ReloadAmmo ReloadAmmo;

        private void OnEnable()
        {
            _inputActions ??= new PlayerInput();
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        public void OnJumpEvent(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _jumpInput = true;
            }
            else if (context.canceled)
            {
                _jumpInput = false;
            }
        }

        public void OnReloadAmmoEvent(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                ReloadAmmo?.Invoke();
            }
        }

        public void OnShootEvent(InputAction.CallbackContext context)
        {
           // ContextShoot = context;
            Shoot?.Invoke(context);
        }

        public void OnMoveEvent(InputAction.CallbackContext context)
        {
            dirMovement = context.ReadValue<Vector2>();
        }

        public void OnMouseScrollEvent(InputAction.CallbackContext context)
        {
            if (context.started) RechooseeWeapon?.Invoke();
        }

        private void Inputs()
        {
            GetDirection?.Invoke(dirMovement);
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
            EventExtensions.Subscribe(ref RechooseeWeapon, subscribers);
            EventExtensions.Subscribe(ref Shoot, subscribers);
            EventExtensions.Subscribe(ref ReloadAmmo, subscribers);
            EventExtensions.Subscribe(ref GetDirection, subscribers);
            EventExtensions.Subscribe(ref SetCameraInput, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref SetMovementInput, unsubscribers);
            EventExtensions.Unsubscribe(ref RechooseeWeapon, unsubscribers);
            EventExtensions.Unsubscribe(ref Shoot, unsubscribers);
            EventExtensions.Unsubscribe(ref ReloadAmmo, unsubscribers);
            EventExtensions.Unsubscribe(ref GetDirection, unsubscribers);
            EventExtensions.Unsubscribe(ref SetCameraInput, unsubscribers);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.GETJumpInput) GetJumpInput,
                (PlayerEventDelegates.GETInputShoot) GetShootInput
            };
        }
    }
}