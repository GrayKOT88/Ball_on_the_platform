using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _score = 0;

        private void Start()
        {
            Enemy.OnEnemyDestroyed += IncrementScore;
            UpdateScoreText();
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
    }
}