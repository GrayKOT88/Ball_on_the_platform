using UnityEngine;
using System.Collections;

namespace NewScript
{
    public class Powerup : MonoBehaviour
    {
        private IObjectPool<Powerup> _powerupPool;
        private float _timeReturn = 15f;

        public void Initialize(IObjectPool<Powerup> powerupPool)
        {
            _powerupPool = powerupPool;
        }

        private void Start()
        {
            StartCoroutine(ReturnAfterStart());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ReturnPowerupInPool();
                EventBus.Publish(new PowerupCollectedEvent());
            }
        }

        private IEnumerator ReturnAfterStart()
        {
            yield return new WaitForSeconds(_timeReturn);
            ReturnPowerupInPool();
        }

        private void ReturnPowerupInPool()
        {            
            _powerupPool.ReturnObject(this);
        }
    }
}