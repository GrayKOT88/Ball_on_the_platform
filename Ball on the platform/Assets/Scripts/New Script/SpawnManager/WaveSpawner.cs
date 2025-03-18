using UnityEngine;

namespace NewScript
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private PowerupPool _powerupPool;
        [SerializeField] private EnemyPool _enemyPool;
        private EnemySpawner _enemySpawner ;
        private PowerupSpawner _powerupSpawner;
        private int _waveNumber = 1;
        private int _enemyCount;

        private void Start()
        {           
            _enemySpawner = new EnemySpawner(_enemyPool);
            _powerupSpawner = new PowerupSpawner(_powerupPool);
            Enemy.OnEnemyDestroyed += UpdateWave;
            StartNextWave();            
        }

        private void UpdateWave()
        {
            _enemyCount--;            
            if (_enemyCount == 0)
            {
                _waveNumber++;
                StartNextWave();
            }
        }

        private void StartNextWave()
        {            
            _enemySpawner.SpawnEnemyWave(_waveNumber);
            _powerupSpawner.SpawnPowerup();            
            _enemyCount = _waveNumber;
        }        
    }
}