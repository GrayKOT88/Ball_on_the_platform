using System;
using UnityEngine;

namespace NewScript
{
    public class Powerup : MonoBehaviour
    {
        private PowerupPool _powerupPool;

        public static event Action OnPowerup;

        public void Initialize(PowerupPool powerupPool)
        {
            _powerupPool = powerupPool;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPowerup?.Invoke();
                _powerupPool.ReturnPowerup(this);                                
            }
        }
    }
}