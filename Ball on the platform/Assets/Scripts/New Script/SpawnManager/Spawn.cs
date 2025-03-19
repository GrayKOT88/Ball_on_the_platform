using UnityEngine;

namespace NewScript
{
    public class Spawn
    {
        private float _spawnRange;
        private GameSettings _gameSettings;

        public Spawn(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _spawnRange = _gameSettings.SpawnRange;
        }

        public Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
            float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
            return new Vector3(spawnPosX, 0, spawnPosZ);
        }
    }
}