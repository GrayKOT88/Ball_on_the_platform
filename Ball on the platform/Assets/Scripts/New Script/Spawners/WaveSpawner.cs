using UnityEngine;
using Zenject;

namespace NewScript
{
    public class WaveSpawner : MonoBehaviour
    {
        [Inject] private EnemyPool _enemyPool;
        [Inject] private PowerupPool _powerupPool;
        [Inject] private GameSettings _gameSettings;

        private EnemySpawner _enemySpawner ;
        private PowerupSpawner _powerupSpawner;
        private int _waveNumber = 1;
        private int _enemyCount;

        private void Start()
        {           
            _enemySpawner = new EnemySpawner(_enemyPool, _gameSettings);
            _powerupSpawner = new PowerupSpawner(_powerupPool, _gameSettings);
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