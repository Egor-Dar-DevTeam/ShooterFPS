using CorePlugin.Core;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class MovementState<T>
    {
        public Controller<T> CurrentState;
        public void SetMovement(Controller<T> newState, T argument)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            EventInitializer.AddHandler(CurrentState,true,false);
            CurrentState.Initialize(argument);
        }
    }
}
