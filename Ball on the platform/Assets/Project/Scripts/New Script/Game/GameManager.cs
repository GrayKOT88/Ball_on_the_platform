using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace NewScript 
{
    public class GameManager : MonoBehaviour
    {        
        [Inject] private ScoreController _scoreController;
        [Inject] private TimerController _timerController;        
        [Inject] private WaveSpawner _waveSpawner;
        [SerializeField] private GameObject _startBackground;
        [SerializeField] private GameObject _restartBackground;

        public bool IsGameActive { get; private set; }

        private void Start()
        {
            _startBackground.SetActive(true);
        }

        public void StartGame()
        {
            IsGameActive = true;
            _timerController.StartTimer();
            _waveSpawner.StartNextWave();            
        }

        public void EndGame()
        {            
            IsGameActive = false;
            _timerController.StopTimer();            
            _scoreController.SaveBestScore();
            _restartBackground.SetActive(true);
        }

        public void RestartGame()
        {            
            EventBus.ClearAllSubscriptions(); // Очищаем все подписки перед загрузкой
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}