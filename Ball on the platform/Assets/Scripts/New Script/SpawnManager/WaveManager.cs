using UnityEngine;

namespace NewScript
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private DownPlatform _downPlatform;
        private EnemySpawner _enemySpawner;
        private PowerupSpawner _powerupSpawner;
        private int _waveNumber = 1;
        private int _enemyCount;

        private void Start()
        {
            _enemySpawner = GetComponent<EnemySpawner>();
            _powerupSpawner = GetComponent<PowerupSpawner>();
            _downPlatform.OnEnemyDestroyed += UpdateWave;
            StartNextWave();            
        }

        private void UpdateWave()
        {
            _enemyCount = FindObjectsOfType<Enemy>().Length;
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
        }        
    }
}