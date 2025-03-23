using UnityEngine;
using Zenject;

namespace NewScript 
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings; 
        [SerializeField] private EnemyPool _enemyPool; 
        [SerializeField] private PowerupPool _powerupPool;
        [SerializeField] private Transform _focalPoint;        
        [SerializeField] private GameObject _powerupIndicator;

        public override void InstallBindings()
        {
            // Привязка GameSettings
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();

            // Привязка EnemyPool
            Container.Bind<EnemyPool>().FromInstance(_enemyPool).AsSingle();

            // Привязка PowerupPool
            Container.Bind<PowerupPool>().FromInstance(_powerupPool).AsSingle();

            // Привязка к точке
            Container.Bind<Transform>().FromInstance(_focalPoint).AsSingle();            

            // Привязка к объекту
            Container.Bind<GameObject>().FromInstance(_powerupIndicator).AsSingle();
        }
    }
}