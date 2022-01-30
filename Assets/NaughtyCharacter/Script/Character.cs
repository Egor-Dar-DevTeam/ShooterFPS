using System;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Attributes.Validation;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    [CoreManagerElement]
    public class Character : MonoBehaviour, IEventHandler, IEventSubscriber
    {
        [SerializeField] [NotNull] private CharacterController _characterController;
        [SerializeField] private float mouseSentivity;
        private Vector3 GetRotationAxis()
        {
            var axis = RotationAxis.Invoke();
            return new Vector3(axis.x, axis.y, mouseSentivity);
        }
        private Controller<CharacterController> _groundMovement;
        private MovementState<CharacterController> movementState;
        private MovementState<Transform> rotationState;
        private Controller<Transform> _playerRotation;
        private PlayerEventDelegates.RotationAxis RotationAxis;
        private LayerMask GroundLayers = LayerMask.NameToLayer("Ground");
        private float SphereCastRadius = 0.35f;
        private float SphereCastDistance = 0.15f;

        private bool CheckGrounded()
        {
            var spherePosition = transform.position;
            spherePosition.y =  transform.position.y + SphereCastRadius - SphereCastDistance;
            var isGrounded = Physics.CheckSphere(spherePosition, SphereCastRadius, GroundLayers, QueryTriggerInteraction.Ignore);

            return isGrounded;
        }
        private void Reset()
        {
            _characterController ??= GetComponent<CharacterController>();
        }
        private void Start()
        {
            _groundMovement = new GroundMovementState();
            _playerRotation = new PlayerRotation();
            movementState = new MovementState<CharacterController>();
            rotationState = new MovementState<Transform>();
            rotationState.SetMovement(_playerRotation, transform);
            movementState.SetMovement(_groundMovement, _characterController);
        }

        private void Updates(Vector2 dir)
        {
            movementState.CurrentState.Updates(dir, Time.deltaTime);
            //rotationState.CurrentState.Updates(Direction(),Time.deltaTime);
        }

        public void InvokeEvents()
        {
        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref RotationAxis, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref RotationAxis, unsubscribers);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.GetDirection) Updates,
                (PlayerEventDelegates.GETIsGrounded) CheckGrounded
            };
        }
    }

}
