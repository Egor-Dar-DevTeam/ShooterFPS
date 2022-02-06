using System;
using System.Threading;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace NaughtyCharacter.Script
{
    public abstract class Controller<T>: IEventHandler, IEventSubscriber
    {
        public abstract void Initialize(T arg, IAttacked attacked);
        public abstract void Updates(Vector3 dir, float deltaTime);
        public abstract void Exit();
        public abstract void InvokeEvents();
        public abstract void Subscribe(params Delegate[] subscribers);
        public abstract void Unsubscribe(params Delegate[] unsubscribers);
        public abstract Delegate[] GetSubscribers();
    }
}