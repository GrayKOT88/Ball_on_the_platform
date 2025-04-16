using System;
using UnityEngine;

namespace NewScript 
{    
    public class TimerModel
    {
        private ILeaderboardService _leaderboardService;
        private const string BestTimeKey = "BestTime";
        private bool IsTimerRunning;
        public float CurrentTime { get; private set; } = 0f;

        public event Action OnTimeUpdated;

        public TimerModel(ILeaderboardService leaderboardService = null)
        {
            _leaderboardService = leaderboardService ?? new YGLeaderboardAdapter();
        }

        public void StartTimer()
        {
            IsTimerRunning = true;
        }

        public void StopTimer()
        {
            IsTimerRunning = false;
            OnTimeUpdated?.Invoke();
        }

        public void UpdateTime(float deltaTime)
        {
            if (IsTimerRunning)
            {
                CurrentTime += deltaTime;
                OnTimeUpdated?.Invoke();
            }
        }

        public void SaveBestTime()
        {
            float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
            if (CurrentTime > bestTime)
            {
                PlayerPrefs.SetFloat(BestTimeKey, CurrentTime);
                
                int timeInSeconds = Mathf.FloorToInt(CurrentTime); //Отправляем время на лидерборд (в секундах)
                _leaderboardService.SubmitTime(timeInSeconds);
            }
        }

        public float LoadBestTime()
        {
            return PlayerPrefs.GetFloat(BestTimeKey, 0f);
        }
    }
}