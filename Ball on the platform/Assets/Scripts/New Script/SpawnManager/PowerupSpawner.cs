using UnityEngine;

namespace NewScript
{
    public class PowerupSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _powerupPrefab;
        private Spawn _spawn = new Spawn();

        public void SpawnPowerup()
        {
            Instantiate(_powerupPrefab, _spawn.GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
        }
    }
}