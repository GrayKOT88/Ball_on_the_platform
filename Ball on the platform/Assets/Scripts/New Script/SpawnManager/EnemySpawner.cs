using UnityEngine;

namespace NewScript
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        private Spawn _spawn = new Spawn();

        public void SpawnEnemyWave(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Instantiate(_enemyPrefab, _spawn.GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
            }
        }
    }
}