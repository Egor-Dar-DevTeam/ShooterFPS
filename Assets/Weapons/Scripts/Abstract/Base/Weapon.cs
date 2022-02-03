using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace Weapons.Scripts.Abstract.Base
{
   public abstract class Weapon : MonoBehaviour, IAttacked, IEventHandler
   {
      [SerializeField] protected int damage;
      [SerializeField] protected float attackSpeed;
      protected Camera camera;

      public abstract void Attack();
      public void InvokeEvents()
      {
         
      }
      public void Subscribe(params Delegate[] subscribers)
      {
         
      }
      public void Unsubscribe(params Delegate[] unsubscribers)
      {
        
      }
   }
}
