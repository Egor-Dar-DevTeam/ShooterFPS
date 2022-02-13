using CorePlugin.Core;

namespace NaughtyCharacter.Script
{
    public class MovementState<T>
    {
        public Controller<T> CurrentState { private set; get; }

        public void SetMovement(Controller<T> newState, T argument, bool isSubscriber)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            EventInitializer.AddHandler(CurrentState, true, false);
            CurrentState.Initialize(argument);
        }
    }
}