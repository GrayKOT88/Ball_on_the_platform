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
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private GameTimer _gameTimer;        
        [SerializeField] private WaveSpawner _waveSpawner;        
        [SerializeField] private GameManager _gameManager;

        public override void InstallBindings()
        {
            // �������� GameSettings
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();

            // �������� EnemyPool
            Container.Bind<EnemyPool>().FromInstance(_enemyPool).AsSingle();

            // �������� PowerupPool
            Container.Bind<PowerupPool>().FromInstance(_powerupPool).AsSingle();

            // �������� � �����
            Container.Bind<Transform>().FromInstance(_focalPoint).AsSingle();            

            // �������� � ������� ����������
            Container.Bind<GameObject>().FromInstance(_powerupIndicator).AsSingle();

            Container.Bind<ScoreCounter>().FromInstance(_scoreCounter).AsSingle();

            Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle();
            
            Container.Bind<WaveSpawner>().FromInstance(_waveSpawner).AsSingle();
            
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        }
    }
}