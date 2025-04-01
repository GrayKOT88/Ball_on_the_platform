using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        private float _currentTime = 0f;
        private bool _isTimerRunning = false;

        private void Start()
        {
            StartTimer();
        }

        private void Update()
        {
            if (_isTimerRunning)
            {
                _currentTime += Time.deltaTime;
                UpdateTimerDisplay();
            }
        }

        public void StartTimer()
        {
            _isTimerRunning = true;
        }

        public void StopTimer()
        {
            _isTimerRunning = false;
        }

        private void UpdateTimerDisplay()
        {
            // Форматирование времени в минуты:секунды
            int minutes = Mathf.FloorToInt(_currentTime / 60);
            int seconds = Mathf.FloorToInt(_currentTime % 60);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}