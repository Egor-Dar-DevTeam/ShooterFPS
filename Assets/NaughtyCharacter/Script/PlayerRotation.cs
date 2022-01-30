using System;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class PlayerRotation : Controller<Transform>
    {
        private Transform _transform;
        [Header("Control Rotation")]
        public float MinPitchAngle = -45.0f;
        public float MaxPitchAngle = 75.0f;

        [Header("Character Orientation")]
        public float MinRotationSpeed = 600.0f; // The turn speed when the player is at max speed (in degrees/second)
        public float MaxRotationSpeed = 1200.0f; // The turn speed when the player is stationary (in degrees/second)

        public override void Initialize(Transform transform)
        {
            _transform = transform;
        }
        public override void Updates(Vector3 dir, float deltaTime)
        {
            OrientToTargetRotation(new Vector3(dir.x, 0, dir.z), deltaTime);

        }
        private void OrientToTargetRotation(Vector3 horizontalMovement, float deltaTime)
        {
            var rotationSpeed = Mathf.Lerp(MaxRotationSpeed, MinRotationSpeed, 0f);
            var targetRotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, rotationSpeed * deltaTime);
        }
        public override void Exit()
        {
        }

        #region Events

        public override void InvokeEvents()
        {
        }
        public override void Subscribe(params Delegate[] subscribers)
        {
        }
        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
        }

        #endregion

    }
}
