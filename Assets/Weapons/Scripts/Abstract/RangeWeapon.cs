using BaseInterfaces;
using UnityEngine;
using Weapons.Scripts.Abstract.Base;

namespace Weapons.Scripts.Abstract
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] protected float reloadTime;
        [SerializeField] protected float attackDistance;
        [SerializeField] protected float ammoCount;

        private void ReloadAmmo()
        {

        }
        public override void Attack()
        {
            RaycastHit hit;
            Debug.DrawRay(camera.transform.position,camera.transform.forward,Color.blue);
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {
                if (hit.collider.TryGetComponent<IDamageble>(out var damageble))
                {
                    damageble.ReceiveDamage(damage);
                }
            }
        }
    }
}
