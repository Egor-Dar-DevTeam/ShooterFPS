using System;
using CorePlugin.Attributes.EditorAddons;
using CorePlugin.Attributes.Validation;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using GeneralEventType;
using NaughtyCharacter.Script;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Weapons.Scripts.Abstract.Base;
using Weapons.Scripts.Abstract.Base.Interfaces;

namespace Weapons.Scripts
{
    [CoreManagerElement]
    public class WeaponAction : MonoBehaviour, IEventHandler, IEventSubscriber
    {
        [NotNull] [SerializeField] private WeaponsData _data;

        private Weapon[] _weapons;
        private IAttacked _currentWeapon;
        private WeaponChange _change;
        private Transform _arm;
        private event PlayerEventDelegates.GetArm GetArm;
        private event GeneralEventDelegates.GetCamera Camera;
        private Camera _camera;
        private int currentWeaponCreated;
        private int currentSelectedWeapon;
        private Coroutine NowShooting;
        private bool isPressed;


        private void Start()
        {
            _camera = Camera.Invoke();
            _change = new WeaponChange();
            currentWeaponCreated = 0;
            _weapons = new Weapon[2];
            _arm = GetArm.Invoke();
            CreateWeapon("Pistol");
            CreateWeapon("Uzi");
            _change.Enter(_weapons[0]);
            _currentWeapon = _change.GetAttackedWeapon();
        }

        private void CreateWeapon(string weaponName)
        {
            _weapons[currentWeaponCreated] =
                Instantiate(_data.GetWeapon(weaponName).gameObject, _arm.position, Quaternion.identity, _arm)
                    .GetComponent<Weapon>();
            _weapons[currentWeaponCreated].Initialize(_camera);
            currentWeaponCreated++;
        }


        private void RechooseeWeapon()
        {
            currentSelectedWeapon++;
            if (currentSelectedWeapon > _weapons.Length - 1) currentSelectedWeapon = 0;
            _change.SetWeapon(_weapons[currentSelectedWeapon]);
            _currentWeapon = _change.GetAttackedWeapon();
        }

        private void ReloadAmmo()
        {
            _currentWeapon.ReloadAmmo();
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            if (!_currentWeapon.IsReady()) return;
            if (context.started)
            {
                Debug.Log(1);
                StartCoroutine(_currentWeapon.Attack(isPressed));
                isPressed = true;
            }
            else if(context.canceled)
            {
                Debug.Log(2);
                isPressed = false;
            }
            
        }

        public void InvokeEvents()
        {
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref GetArm, subscribers);
            EventExtensions.Subscribe(ref Camera, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Subscribe(ref GetArm, unsubscribers);
            EventExtensions.Subscribe(ref Camera, unsubscribers);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.RechooseeWeapon) RechooseeWeapon,
                (PlayerEventDelegates.Shoot) Shoot,
                (PlayerEventDelegates.ReloadAmmo) ReloadAmmo
            };
        }
    }
}