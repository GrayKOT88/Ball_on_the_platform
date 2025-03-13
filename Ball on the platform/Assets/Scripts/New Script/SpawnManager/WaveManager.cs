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
            _enemiesRemaining = _waveNumber;
            _enemySpawner.SpawnEnemyWave(_waveNumber);
            _powerupSpawner.SpawnPowerup();

            Debug.Log("Wave " + _waveNumber + " started with " + _enemiesRemaining + " enemies.");

            foreach (var enemy in FindObjectsOfType<EnemyHealth>())
            {
                enemy.OnEnemyDestroyed += HandleEnemyDestroyed;                
            }           
        }

        private void HandleEnemyDestroyed(GameObject enemy)
        {
            Debug.Log("Enemy destroyed. Enemies remaining: " + _enemiesRemaining);
            
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.OnEnemyDestroyed -= HandleEnemyDestroyed;
            }

            _enemiesRemaining--;
            
            if (_enemiesRemaining <= 0)
            {
                Debug.Log("All enemies destroyed. Starting next wave.");
                _waveNumber++;
                StartNextWave();
            }
        }
    }
}