using System.Collections.Generic;
using UnityEngine;

namespace NewScript
{
    public class PowerupPool : MonoBehaviour
    {
        [SerializeField] private Powerup _prefabPowerup;
        [SerializeField] private int _poolSize = 5;

        private Queue<Powerup> _powerupPool = new Queue<Powerup>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
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

        public Powerup GetPowerup()
        {
            if (_powerupPool.Count == 0)
            {
                ExpandPool();
            }

            Powerup powerup = _powerupPool.Dequeue();
            powerup.gameObject.SetActive(true);
            return powerup;
        }

        public void ReturnPowerup(Powerup powerup)
        {
            powerup.gameObject.SetActive(false);
            _powerupPool.Enqueue(powerup);
        }
    }
}