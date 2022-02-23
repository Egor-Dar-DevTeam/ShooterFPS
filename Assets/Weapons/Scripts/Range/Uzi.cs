using System.Collections;
using System.Collections.Generic;
using BaseInterfaces;
using UnityEngine;
using Weapons.Scripts.Abstract;

namespace Weapons.Scripts
{
    public class Uzi : RangeWeapon
    {
        public override IEnumerator Attack(bool? isPressed)
        {
            bool IsPressed = isPressed != null ? (bool) isPressed : false;
            Debug.Log(IsPressed);
            while (IsPressed)
            {
                if (ammoCountCurrent == 0) yield break;
                AttackStoped = false;
                RaycastHit hit;
                Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.blue);
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
                {
                    if (hit.collider.TryGetComponent<IDamageble>(out var damageable))
                    {
                        damageable.ReceiveDamage(damage);
                    }
                }

                ammoCountCurrent = Mathf.Clamp(ammoCountCurrent - 1, 0, MayBeInLoop);
                yield return new WaitForSeconds(attackSpeed);
            }

            AttackStoped = true;
        }
    }
}