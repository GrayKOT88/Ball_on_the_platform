using System;
using UnityEngine;

namespace NewScript 
{
    public class ScoreModel
    {
        private const string BestScoreKey = "BestScore";
        private int CurrentScore;
        public int BestScore { get; private set; }

        public event Action<int> OnScoreUpdated;        

        public ScoreModel()
        {
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
            }
        }

        private void LoadBestScore()
        {
            BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);            
        }
    }
}