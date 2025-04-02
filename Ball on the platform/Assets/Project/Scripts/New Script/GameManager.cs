using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using System.Collections;

namespace NewScript 
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private ScoreCounter _scoreCounter;
        [Inject] private GameTimer _gameTimer;        
        [Inject] private WaveSpawner _waveSpawner;
        private float _restartDelay = 2f;

        public bool IsGameActiv { get; private set; }

        public void StartGame()
        {
            IsGameActiv = true;
            _gameTimer.StartTimer();
            _waveSpawner.StartNextWave();            
        }

        public void EndGame()
        {            
            IsGameActiv = false;
            _gameTimer.StopTimer();
            _scoreCounter.SaveBestScore();
            StartCoroutine(RestartGameAfterDelay()); 
        }

        private IEnumerator RestartGameAfterDelay()
        {
            yield return new WaitForSeconds(_restartDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}