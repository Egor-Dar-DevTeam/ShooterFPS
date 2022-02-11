using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Extensions;
using Weapons.Scripts.Abstract.Base;
using Weapons.Scripts.Abstract.Base.Interfaces;
using IEventHandler = CorePlugin.Cross.Events.Interface.IEventHandler;

namespace NaughtyCharacter.Script
{
    public class WeaponChange
    {
        private Weapon currentWeapon;
        public IAttacked GetAttackedWeapon() => currentWeapon;

        public void SetWeapon(Weapon newWeapon)
        {
            currentWeapon?.Exit(false);
            currentWeapon = newWeapon;
            currentWeapon.Exit(true);
            EventInitializer.AddHandler(newWeapon, true, false);
        }
    }
}