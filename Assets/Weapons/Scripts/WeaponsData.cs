using System;
using UnityEngine;
using Weapons.Scripts.Abstract.Base;

namespace Weapons.Scripts
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data", order = 0)]
    public class WeaponsData : ScriptableObject
    {
        [SerializeField] private WeaponVariant[] _weaponVariant;
        public WeaponVariant GetWeaponVariant(int index) => _weaponVariant[index];
    }
[Serializable]
    public struct WeaponVariant
    {
        public string weaponName;
        public Weapon Weapon;
    }

}