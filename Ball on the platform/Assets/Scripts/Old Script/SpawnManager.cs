using UnityEngine;

namespace OldScript
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public GameObject powerPrefab;
        private float spawnRange = 9f;
        public int enemyCount;
        public int waveNumder = 1;

        private void Start()
        {
            SpawnEnemyWave(waveNumder);
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if(enemyCount == 0)
            {
                waveNumder++;
                SpawnEnemyWave(waveNumder);
                Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
            }
        }
        private void SpawnEnemyWave(int enemiesToSpawn)
        {
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
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