using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections;

namespace NewScript 
{
    public class GameManager : MonoBehaviour
    {        
        [Inject] private ScoreController _scoreController;
        [Inject] private TimerController _timerController;        
        [Inject] private WaveSpawner _waveSpawner;
        private float _restartDelay = 1f;

        public bool IsGameActive { get; private set; }

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
            StartCoroutine(RestartGameAfterDelay()); 
        }

        private IEnumerator RestartGameAfterDelay()
        {
            yield return new WaitForSeconds(_restartDelay);
            EventBus.ClearAllSubscriptions(); // Очищаем перед загрузкой
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}