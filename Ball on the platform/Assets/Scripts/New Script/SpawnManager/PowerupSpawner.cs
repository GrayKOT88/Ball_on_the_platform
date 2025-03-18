using UnityEngine;

namespace NewScript
{
    public class PowerupSpawner
    {        
        private PowerupPool _powerupPool;
        private Spawn _spawn = new Spawn();

        public PowerupSpawner(PowerupPool poweupPool)
        {
            _powerupPool = poweupPool;
        }

        public void SpawnPowerup()
        {            
            Powerup powerup = _powerupPool.GetPowerup();
            powerup.transform.position = _spawn.GenerateSpawnPosition();            
        }
    }
}