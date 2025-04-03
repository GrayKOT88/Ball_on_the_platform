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
        private float _restartDelay = 2f;

        public bool IsGameActiv { get; private set; }

        public void StartGame()
        {
            IsGameActiv = true;
            _timerController.StartTimer();
            _waveSpawner.StartNextWave();            
        }

        public void EndGame()
        {            
            IsGameActiv = false;
            _timerController.StopTimer();            
            _scoreController.SaveBestScore();
            StartCoroutine(RestartGameAfterDelay()); 
        }

        private IEnumerator RestartGameAfterDelay()
        {
            yield return new WaitForSeconds(_restartDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}