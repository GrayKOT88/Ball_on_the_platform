using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace NewScript
{
    public class PowerupPool : MonoBehaviour, IObjectPool<Powerup>
    {
        [SerializeField] private Powerup _prefabPowerup;        
        [Inject] private GameSettings _settings;

        private Queue<Powerup> _powerupPool = new Queue<Powerup>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _settings.PowerupPoolSize; i++)
            {
                ExpandPool();
            }
        }

        private void ExpandPool()
        {
            Powerup powerup = Instantiate(_prefabPowerup, transform);
            powerup.gameObject.SetActive(false);
            _powerupPool.Enqueue(powerup);
            powerup.Initialize(this);
        }

        public Powerup GetObject()
        {
            if (_powerupPool.Count == 0)
            {
                ExpandPool();
            }
            Powerup powerup = _powerupPool.Dequeue();
            powerup.gameObject.SetActive(true);
            return powerup;
        }

        public void ReturnObject(Powerup powerup)
        {
            powerup.gameObject.SetActive(false);
            _powerupPool.Enqueue(powerup);
        }
    }
}