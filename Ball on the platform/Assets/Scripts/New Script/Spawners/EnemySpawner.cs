using UnityEngine;

namespace NewScript
{
    public class EnemySpawner
    {
        private IObjectPool<Enemy> _enemyPool; // интерфейс вместо конкретной реализации        
        private Spawn _spawn;

        public EnemySpawner(IObjectPool<Enemy> enemyPool, GameSettings gameSettings)
        {
            _enemyPool = enemyPool;
            _spawn = new Spawn(gameSettings);
        }

        public void SpawnEnemyWave(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {                
                Enemy enemy = _enemyPool.GetObject(); // метод из интерфейса
                enemy.transform.position = _spawn.GenerateSpawnPosition();                
            }
        }
    }
}