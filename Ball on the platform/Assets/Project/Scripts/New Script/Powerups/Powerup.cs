using System;
using UnityEngine;

namespace NewScript
{
    public class Powerup : MonoBehaviour
    {
        private IObjectPool<Powerup> _powerupPool;
        
        public void Initialize(IObjectPool<Powerup> powerupPool)
        {
            _powerupPool = powerupPool;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _powerupPool.ReturnObject(this);                
                EventBus.Publish(new PowerupCollectedEvent());
            }
        }
    }
}