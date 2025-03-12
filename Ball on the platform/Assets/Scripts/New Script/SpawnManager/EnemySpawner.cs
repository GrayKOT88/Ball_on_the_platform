using UnityEngine;

namespace NewScript
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private GameObject _enemyPrefab;
        private Spawn _spawn = new Spawn();

        public void SpawnEnemyWave(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                //Instantiate(_enemyPrefab, _spawn.GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
                Enemy enemy = _enemyPool.GetEnemy();
                enemy.transform.position = _spawn.GenerateSpawnPosition();
                //enemy.transform.rotation = _enemyPrefab.transform.rotation;
                //enemy.gameObject.SetActive(true);
            }
        }
    }
}