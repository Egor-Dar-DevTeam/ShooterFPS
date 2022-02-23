using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;

namespace NaughtyCharacter.Script
{
    public static class PlayerEventDelegates
    {
        public delegate void GetDirection(Vector2 dir);
        public delegate bool GETHasMovementInput();
        public delegate bool GETInputShoot();      
        public delegate Transform GetArm();
        public delegate void Shoot(InputAction.CallbackContext context);
        public delegate void ReloadAmmo();
        public delegate void RechooseeWeapon();
        public delegate bool GETJumpInput();
        public delegate void SetMovementInput(Vector2 axis);
        public delegate void SetCameraInput(Vector2 axis);
    }
}
