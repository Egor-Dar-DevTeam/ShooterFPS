using System;
using System.Collections;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using GeneralEventType;
using UnityEngine;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace Weapons.Scripts.Abstract.Base
{
    public abstract class Weapon : MonoBehaviour, IAttacked
    {
        [SerializeField] protected bool isSingleShoot;
        [SerializeField] protected int damage;
        [SerializeField] protected float attackSpeed;
        protected Camera camera;

        public virtual void Initialize(Camera camera)
        {
            this.camera = camera;
        }
        
        public abstract bool IsReady();
        public abstract bool IsSingleShoot();
        public abstract void ReloadAmmo();

        public abstract IEnumerator Attack(bool? isPressed);

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}