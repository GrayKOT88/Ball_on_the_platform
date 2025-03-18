using UnityEngine;

namespace NewScript
{
    public class EnemySpawner
    {
        private EnemyPool _enemyPool;        
        private Spawn _spawn = new Spawn();

        public EnemySpawner(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void SpawnEnemyWave(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {                
                Enemy enemy = _enemyPool.GetEnemy();
                enemy.transform.position = _spawn.GenerateSpawnPosition();                
            }
        }
    }
}