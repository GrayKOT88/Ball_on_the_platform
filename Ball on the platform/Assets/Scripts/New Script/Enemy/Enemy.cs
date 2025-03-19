using UnityEngine;
using System;

namespace NewScript
{
    public class Enemy : MonoBehaviour
    {        
        [SerializeField] private GameSettings _gameSettings;
        private IObjectPool<Enemy> _enemyPool;
        private Rigidbody _enemyRb;
        private Transform _playerTransform;

        public static event Action OnEnemyDestroyed;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
            _playerTransform = GameObject.Find("Player").transform;
        }

        public void Initialize(IObjectPool<Enemy> enemyPool)
        {
            _enemyPool = enemyPool;
        }

        private void Update()
        {
            if (_playerTransform != null)
            {
                Vector3 lookDirection = (_playerTransform.position - transform.position).normalized;
                _enemyRb.AddForce(lookDirection * _gameSettings.EnemySpeed);
                if (transform.position.y < _gameSettings.LowerBoundDestroy)
                {
                    _enemyPool.ReturnObject(this);
                    OnEnemyDestroyed?.Invoke();                    
                }
            }
        }
    }
}