using UnityEngine;

namespace NewScript
{
    public class PowerupSpawner : MonoBehaviour
    {        
        [SerializeField] private PowerupPool _powerupPool;
        private Spawn _spawn = new Spawn();

        public void SpawnPowerup()
        {
            
            Powerup powerup = _powerupPool.GetPowerup();
            powerup.transform.position = _spawn.GenerateSpawnPosition();            
        }
    }
}