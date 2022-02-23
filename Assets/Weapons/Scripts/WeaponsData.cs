using System;
using UnityEngine;
using Weapons.Scripts.Abstract.Base;

namespace Weapons.Scripts
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data", order = 0)]
    public class WeaponsData : ScriptableObject
    {
        [SerializeField] private WeaponVariant[] _weaponVariant;

        public Weapon GetWeapon(string weaponName)
        {
            Weapon weapon = null; 
            for (int i = 0; i < _weaponVariant.Length; i++)
            {
                if (_weaponVariant[i].weaponName != weaponName) continue;
                    weapon = _weaponVariant[i].Weapon;
                    break;
            }
            return weapon;
        }
    }
[Serializable]
    public struct WeaponVariant
    {
        public string weaponName;
        public Weapon Weapon;
    }

}