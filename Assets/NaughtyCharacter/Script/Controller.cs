using System;
using System.Threading;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public abstract class Controller<T>: IEventHandler
    {
        public abstract void Initialize(T characterController);
        public abstract void Updates(Vector3 dir, float deltaTime);
        public abstract void Exit();
        public abstract void InvokeEvents();
        public abstract void Subscribe(params Delegate[] subscribers);
        public abstract void Unsubscribe(params Delegate[] unsubscribers);
    }
}