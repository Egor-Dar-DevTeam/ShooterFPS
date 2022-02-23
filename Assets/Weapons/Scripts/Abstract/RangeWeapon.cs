using System.Collections;
using BaseInterfaces;
using UnityEngine;
using Weapons.Scripts.Abstract.Base;

namespace Weapons.Scripts.Abstract
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] protected float reloadTime;
        [SerializeField] protected float attackDistance;

        [Space]

        #region Ammo

        [SerializeField]
        protected int ammoCountCurrent; //Патронов в обойме на данный момент

        [SerializeField] protected int ammoCountLeft; //Осталось патронов всего
        [SerializeField] protected int ammoCountLeftMax; //Макс патронов всего
        [SerializeField] protected int MayBeInLoop; //может быть в обойме

        #endregion

        protected bool AttackStoped = true;

        public override void ReloadAmmo()
        {
            if (ammoCountCurrent == MayBeInLoop || ammoCountLeft == 0 || MayBeInLoop == 0) return;
            ammoCountLeft = Mathf.Clamp(ammoCountLeft - (MayBeInLoop - ammoCountCurrent), 0, ammoCountLeftMax);
            ammoCountCurrent = Mathf.Clamp(ammoCountCurrent + (MayBeInLoop - ammoCountCurrent), 0, MayBeInLoop);
        }

        public override bool IsReady() => AttackStoped;
        public override bool IsSingleShoot() => isSingleShoot;
    }
}