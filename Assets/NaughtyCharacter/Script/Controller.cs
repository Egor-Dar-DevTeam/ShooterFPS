using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public abstract class Controller<T>: IEventHandler
    {
        public abstract void Initialize(T arg);
        public abstract void Updates(Vector3 dir, float deltaTime);
        public abstract void Exit();
        public abstract void InvokeEvents();
        public abstract void Subscribe(params Delegate[] subscribers);
        public abstract void Unsubscribe(params Delegate[] unsubscribers);
    }
}