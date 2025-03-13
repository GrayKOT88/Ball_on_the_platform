using System;
using UnityEngine;

namespace NewScript
{
    public class EnemyHealth : MonoBehaviour
    {
        private float _fallThreshold = -5f;
        private EnemyPool _enemyPool;

        public event Action<GameObject> OnEnemyDestroyed;

        private void Start()
        {
            _enemyPool = FindObjectOfType<EnemyPool>();
        }

        private void Update()
        {
            if (transform.position.y < _fallThreshold)
            {
                OnEnemyDestroyed?.Invoke(gameObject);                
                ReturnEnemyToPool();
            }
        }

        private void ReturnEnemyToPool()
        {            
            if (_enemyPool != null)
            {
                _enemyPool.ReturnEnemy(GetComponent<Enemy>());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}