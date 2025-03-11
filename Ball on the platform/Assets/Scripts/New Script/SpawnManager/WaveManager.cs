using UnityEngine;

namespace NewScript
{
    public class WaveManager : MonoBehaviour
    {
        private int _waveNumber = 1;
        private EnemySpawner _enemySpawner;
        private PowerupSpawner _powerupSpawner;
        private int _enemiesRemaining;

        private void Start()
        {
            _enemySpawner = GetComponent<EnemySpawner>();
            _powerupSpawner = GetComponent<PowerupSpawner>();
            StartNextWave();
        }

        private void StartNextWave()
        {
            _enemySpawner.SpawnEnemyWave(_waveNumber);
            _powerupSpawner.SpawnPowerup();

            foreach (var enemy in FindObjectsOfType<EnemyHealth>())
            {
                enemy.OnEnemyDestroyed += HandleEnemyDestroyed;
            }

            _enemiesRemaining = _waveNumber;
        }

        private void HandleEnemyDestroyed(GameObject enemy)
        {
            _enemiesRemaining--;

            if (_enemiesRemaining <= 0)
            {
                _waveNumber++;
                StartNextWave();
            }
        }
    }
}