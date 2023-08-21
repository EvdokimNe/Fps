using Unity.FPS.Game;
using UnityEngine;

namespace FPS.Scripts.AI.ChangeLogic
{
    public class DonutObject : MonoBehaviour
    {
        private float _damage;

        private bool _canDamage;

        public void SetCanDamage(bool canDamage)
        {
            _canDamage = canDamage;
        }

        public void SetDamage(float damage)
        {
            _canDamage = true;
            _damage = damage;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!_canDamage)
            {
                return;
            }
            
            if (other.gameObject.GetComponent<PlayerMarker>() == null)
            {
                return;
            }
            
            var comp = other.gameObject.GetComponent<Damageable>();

            if (comp != null)
            {
                _canDamage = false;
                comp.InflictDamage(_damage, false, gameObject);
            }
        }
    }
}