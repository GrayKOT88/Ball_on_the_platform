using UnityEngine;

namespace NewScript
{
    public class SpawnManager : MonoBehaviour
    {
        private float spawnRange = 9f;
        private int _enemyCount;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _powerPrefab;
        [SerializeField] private int _waveNumder;

        
        private void Update()
        {
            _enemyCount = FindObjectsOfType<Enemy>().Length;
            if(_enemyCount == 0)
            {
                _waveNumder++;
                SpawnEnemyWave(_waveNumder);
                Instantiate(_powerPrefab, GenerateSpawnPosition(), _powerPrefab.transform.rotation);
            }
        }
        private void SpawnEnemyWave(int enemiesToSpawn)
        {
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
            }
        }
        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
            return randomPos;
        }
    }
}