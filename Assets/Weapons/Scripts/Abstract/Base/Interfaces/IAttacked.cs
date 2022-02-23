using System.Collections;

namespace Weapons.Scripts.Abstract.Base.Interfaces
{
    public interface IAttacked
    {
        public bool IsSingleShoot();
        public bool IsReady();
        public void ReloadAmmo();
        public IEnumerator Attack(bool? isPressed);
    }
}