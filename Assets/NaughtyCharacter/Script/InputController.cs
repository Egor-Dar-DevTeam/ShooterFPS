using System;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    [CoreManagerElement]
    public class InputController : MonoBehaviour, IEventSubscriber
    {
        private Vector3 _movementInput;
        private bool _hasMovementInput;
        private bool GetHasMovementInput()
        {
            return _hasMovementInput;
        }

        private void SetMovementInput(Vector2 axis)
        {
            var movementInput = (Vector3.forward * axis.y + Vector3.right * axis.x);
            if (movementInput.sqrMagnitude > 1f)
            {
                movementInput.Normalize();
            }
            var hasMovementInput = movementInput.sqrMagnitude > 0.0f;

            _movementInput = movementInput;
            _hasMovementInput = hasMovementInput;
        }


        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.SetMovementInput) SetMovementInput,
                (PlayerEventDelegates.GETHasMovementInput) GetHasMovementInput
            };
        }
    }
}
