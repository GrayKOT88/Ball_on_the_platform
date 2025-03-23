using System;
using UnityEngine;

namespace NewScript
{
    public class Powerup : MonoBehaviour
    {
        private IObjectPool<Powerup> _powerupPool;

        public static event Action OnPowerup;

        public void Initialize(IObjectPool<Powerup> powerupPool)
        {
            _powerupPool = powerupPool;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPowerup?.Invoke();
                _powerupPool.ReturnObject(this);                
            }
        }
    }
}