using UnityEngine;

namespace NewScript
{
    public class PowerupSpawner
    {        
        private IObjectPool<Powerup> _powerupPool; // интерфейс
        private Spawn _spawn;

        public PowerupSpawner(IObjectPool<Powerup> poweupPool, GameSettings gameSettings)
        {
            _powerupPool = poweupPool;
            _spawn = new Spawn(gameSettings);
        }

        public void SpawnPowerup()
        {            
            Powerup powerup = _powerupPool.GetObject(); // метод из интерфейса
            powerup.transform.position = _spawn.GenerateSpawnPosition();            
        }
    }
}