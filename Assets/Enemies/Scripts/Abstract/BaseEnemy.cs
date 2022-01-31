using BaseInterfaces;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageble, IEventHandler
    {
        [SerializeField] protected int MaxHealth;
        protected int CurrentHealth;
        protected int Damage;
        private EnemiesDelegates.UIReceiveDamage receiveDamageUI;

        public void Awake()
        {
            CurrentHealth = MaxHealth;
        }
        public void ReceiveDamage(int damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            receiveDamageUI?.Invoke(damage, CurrentHealth); 
        }
        #region IEventHandler
        public void InvokeEvents()
        {

        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref receiveDamageUI, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref receiveDamageUI, unsubscribers);
        }
        #endregion 
    }
} 
