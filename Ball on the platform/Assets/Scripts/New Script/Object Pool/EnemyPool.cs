using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace NewScript
{
    public class EnemyPool : MonoBehaviour, IObjectPool<Enemy>
    {
        [SerializeField] private Enemy _prefabEnemy;
        [SerializeField] private Transform _playerTransform;        
        [Inject] private GameSettings _settings;

        private Queue<Enemy> _enemyPool = new Queue<Enemy>();

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _settings.EnemyPoolSize; i++)
            {
                ExpandPool();
            }
        }

        private void ExpandPool()
        {
            Enemy enemy = Instantiate(_prefabEnemy, transform);
            enemy.gameObject.SetActive(false);
            _enemyPool.Enqueue(enemy);
            enemy.Initialize(this, _settings, _playerTransform);
        }

        public Enemy GetObject()
        {
            if (_enemyPool.Count == 0)
            {
                ExpandPool();
            }
            Enemy enemy = _enemyPool.Dequeue();
            enemy.gameObject.SetActive(true);
            return enemy;
        }

        public void ReturnObject(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _enemyPool.Enqueue(enemy);
        }
    }
}