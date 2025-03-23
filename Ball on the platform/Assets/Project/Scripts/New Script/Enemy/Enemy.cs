using UnityEngine;
using System;

namespace NewScript
{
    public class Enemy : MonoBehaviour
    {
        private IObjectPool<Enemy> _enemyPool;
        private Transform _playerTransform;
        private GameSettings _settings;
        private Rigidbody _enemyRb;

        public static event Action OnEnemyDestroyed;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();            
        }

        public void Initialize(IObjectPool<Enemy> enemyPool, GameSettings gameSettings, Transform playerTransform)
        {
            _enemyPool = enemyPool;
            _settings = gameSettings;
            _playerTransform = playerTransform;
        }

        private void FixedUpdate()
        {
            if (_playerTransform != null)
            {
                Vector3 lookDirection = (_playerTransform.position - transform.position).normalized;
                _enemyRb.AddForce(lookDirection * _settings.EnemySpeed);
                if (transform.position.y < _settings.LowerBoundDestroy)
                {
                    _enemyPool.ReturnObject(this);
                    OnEnemyDestroyed?.Invoke();                    
                }
            }
        }
    }
}