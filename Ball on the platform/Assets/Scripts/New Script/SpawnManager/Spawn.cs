using UnityEngine;

namespace NewScript
{
    public class Spawn
    {
        private float _spawnRange = 9f;

        public Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
            float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
            return new Vector3(spawnPosX, 0, spawnPosZ);
        }
    }
}