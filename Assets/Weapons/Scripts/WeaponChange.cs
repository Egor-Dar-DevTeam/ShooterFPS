using System;
using CorePlugin.Core;
using Weapons.Scripts.Abstract.Base;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace Weapons.Scripts
{
    public class WeaponChange
    {
        private Weapon currentWeapon;
        public IAttacked GetAttackedWeapon() => currentWeapon;

        public void Enter(Weapon newWeapon)
        {
            currentWeapon = newWeapon;
        }
        public void SetWeapon(Weapon newWeapon)
        {
            currentWeapon?.SetActive(false);
            currentWeapon = newWeapon;
            currentWeapon.SetActive(true);
            //EventInitializer.AddHandler(newWeapon, true, false);
        }
    }
}