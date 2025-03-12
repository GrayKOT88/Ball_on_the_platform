using System;
using UnityEngine;

namespace NewScript
{
    public class EnemyHealth : MonoBehaviour
    {
        private float _fallThreshold = -5f;

        public event Action<GameObject> OnEnemyDestroyed;

        private void Update()
        {
            if (transform.position.y < _fallThreshold)
            {
                OnEnemyDestroyed?.Invoke(gameObject);
                //Destroy(gameObject);
                ReturnEnemyToPool();
            }
        }

        private void ReturnEnemyToPool()
        {
            EnemyPool enemyPool = FindObjectOfType<EnemyPool>();
            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(GetComponent<Enemy>());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}