using UnityEngine;
using System;

namespace NewScript
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        private EnemyPool _enemyPool;
        private Rigidbody _enemyRb;
        private Transform _playerTransform;

        public static event Action OnEnemyDestroyed;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
            _playerTransform = GameObject.Find("Player").transform;
        }

        public void Initialize(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        private void Update()
        {
            if (_playerTransform != null)
            {
                Vector3 lookDirection = (_playerTransform.position - transform.position).normalized;
                _enemyRb.AddForce(lookDirection * _speed);
                if (transform.position.y < -10)
                {
                    _enemyPool.ReturnEnemy(this);
                    OnEnemyDestroyed?.Invoke();                    
                }
            }
        }
    }
}