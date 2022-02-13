using System;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Attributes.Validation;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    [CoreManagerElement]
    public class Character : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] [NotNull] private CharacterController _characterController;

        private Controller<CharacterController> _groundMovement;
        private MovementState<CharacterController> movementState;

        private void Reset()
        {
            _characterController ??= GetComponent<CharacterController>();
        }

        private void Start()
        {
            _groundMovement = new GroundMovementState();
            movementState = new MovementState<CharacterController>();
            movementState.SetMovement(_groundMovement, _characterController,true);
        }

        private void Updates(Vector2 dir)
        {
            movementState.CurrentState.Updates(dir, Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.5f);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.GetDirection) Updates
            };
        }
    }
}