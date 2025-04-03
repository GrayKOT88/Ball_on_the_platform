using UnityEngine;
using Zenject;

namespace NewScript 
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _gameSettings;
        
        [SerializeField] private EnemyPool _enemyPool; 
        [SerializeField] private PowerupPool _powerupPool;        
       
        [SerializeField] private WaveSpawner _waveSpawner;        
        [SerializeField] private GameManager _gameManager;

        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private TimerController _timerController;

        public override void InstallBindings()
        {           
            // Настройки игры (ScriptableObject)
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();

            // Пул объектов 
            Container.Bind<EnemyPool>().FromInstance(_enemyPool).AsSingle();
            Container.Bind<PowerupPool>().FromInstance(_powerupPool).AsSingle();

            // Игровые компоненты
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<WaveSpawner>().FromInstance(_waveSpawner).AsSingle();

            // MVC для счёта
            Container.Bind<ScoreModel>().AsSingle();
            Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();
            Container.Bind<ScoreController>().AsSingle().NonLazy(); // Автоматически создастся

            // MVC для таймера 
            Container.Bind<TimerModel>().AsSingle();
            Container.Bind<TimerView>().FromInstance(_timerView).AsSingle();
            Container.Bind<TimerController>().FromInstance(_timerController).AsSingle();
        }
    }
}