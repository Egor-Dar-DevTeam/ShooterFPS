using UnityEngine;

namespace NaughtyCharacter.Script
{
    public static class PlayerEventDelegates
    {
        public delegate void GetDirection(Vector2 dir);
        public delegate bool GETHasMovementInput();
        public delegate bool GETInputShoot();      
        public delegate bool GETJumpInput();
        public delegate void SetMovementInput(Vector2 axis);
        public delegate void SetCameraInput(Vector2 axis);
    }
}
