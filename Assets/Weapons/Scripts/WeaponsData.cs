using System;
using CorePlugin.Attributes.EditorAddons.SelectAttributes;
using CorePlugin.Attributes.Validation;
using UnityEngine;
using Weapons.Scripts.Abstract.Base;
using Weapons.Scripts.Abstract.Base.Interfaces;

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