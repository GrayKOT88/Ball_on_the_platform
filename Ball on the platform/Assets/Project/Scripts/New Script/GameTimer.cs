using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _bestTimeText;
        private float _currentTime = 0f;
        private bool _isTimerRunning = false;
        private const string BestTimeKey = "BestTime";

        private void Start()
        {
            LoadBestTime();            
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
            SaveBestTime();
        }

        private void UpdateTimerDisplay()
        {
            // Форматирование времени в минуты:секунды
            int minutes = Mathf.FloorToInt(_currentTime / 60);
            int seconds = Mathf.FloorToInt(_currentTime % 60);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void SaveBestTime()
        {
            float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
            if (_currentTime > bestTime)
            {
                PlayerPrefs.SetFloat(BestTimeKey, _currentTime);                
            }
        }

        private void LoadBestTime()
        {
            float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
            int minutes = Mathf.FloorToInt(bestTime / 60);
            int seconds = Mathf.FloorToInt(bestTime % 60);
            _bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}