using System;
using UnityEngine;

namespace NewScript 
{    
    public class TimerModel
    {
        private bool IsTimerRunning;
        private const string BestTimeKey = "BestTime";
        public float CurrentTime { get; private set; } = 0f;

        public event Action OnTimeUpdated;

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
            }
        }

        public float LoadBestTime()
        {
            return PlayerPrefs.GetFloat(BestTimeKey, 0f);
        }
    }
}