using CorePlugin.Core;
using UnityEngine;
using Weapons.Scripts;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace NaughtyCharacter.Script
{
    public class MovementState<T>
    {
        public Controller<T> CurrentState { private set; get; }

        public void SetMovement(Controller<T> newState, WeaponsData data, T argument,Transform arm, bool isSubscriber)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            if (isSubscriber) EventInitializer.Subscribe(CurrentState);
            EventInitializer.AddHandler(CurrentState, true, false);
            CurrentState.Initialize(argument, data, arm);
        }
    }
}