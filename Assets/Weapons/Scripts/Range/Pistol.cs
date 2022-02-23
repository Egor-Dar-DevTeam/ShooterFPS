using System.Collections;
using BaseInterfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons.Scripts.Abstract;

namespace Weapons.Scripts
{
    public class Pistol : RangeWeapon
    {
        public override IEnumerator Attack(bool? isPressed)
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
            AttackStoped = true;
        }
    }
}