using System;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using GeneralEventType;
using NaughtyCharacter.Script;
using UnityEngine;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace Weapons.Scripts.Abstract.Base
{
    public abstract class Weapon : MonoBehaviour, IAttacked, IEventHandler
    {
        [SerializeField] protected int damage;
        [SerializeField] protected float attackSpeed;
        protected Camera camera;
        private GeneralEventDelegates.GetCamera GetCamera;

        private void Start()
        {
            camera = GetCamera.Invoke();
        }
        public abstract void Attack();

        public void Exit()
        {
            
        }
        public void InvokeEvents()
        {

        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref GetCamera, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref GetCamera, unsubscribers);
        }
    }
}
