using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _bestScoreText;
        private int _score = 0;
        private const string BestScoreKey = "BestScore";

        private void Start()
        {
            Enemy.OnEnemyDestroyed += IncrementScore;
            UpdateScoreText();
            LoadBestScore();
        }

        private void IncrementScore()
        {
            _score++;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreText.text = $"{_score}";
        }

        private void OnDestroy()
        {
            Enemy.OnEnemyDestroyed -= IncrementScore;
        }

        public void SaveBestScore()
        {
            int bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
            if (_score > bestScore)
            {
                PlayerPrefs.SetFloat(BestScoreKey, _score);                
            }
        }

        private void LoadBestScore()
        {
            int bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
            
            _bestScoreText.text = $"{bestScore}";
        }
    }
}