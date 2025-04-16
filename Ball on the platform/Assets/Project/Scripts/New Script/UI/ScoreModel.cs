using System;
using UnityEngine;

namespace NewScript 
{
    public class ScoreModel
    {
        private ILeaderboardService _leaderboardService;
        private const string BestScoreKey = "BestScore";
        private int CurrentScore;
        public int BestScore { get; private set; }

        public event Action<int> OnScoreUpdated;        

        public ScoreModel(ILeaderboardService leaderboardService = null)
        {
            _leaderboardService = leaderboardService ?? new YGLeaderboardAdapter();
            LoadBestScore();
        }

        public void IncrementScore(EnemyDestroyedEvent evt)
        {
            CurrentScore++;
            OnScoreUpdated?.Invoke(CurrentScore);
        }

        public void SaveBestScore()
        {
            if (CurrentScore > BestScore)
            {
                BestScore = CurrentScore;
                PlayerPrefs.SetInt(BestScoreKey, BestScore);
                _leaderboardService.SubmitScore(BestScore); // Отправляем на лидерборд
            }
        }

        private void LoadBestScore()
        {
            BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);            
        }
    }
}