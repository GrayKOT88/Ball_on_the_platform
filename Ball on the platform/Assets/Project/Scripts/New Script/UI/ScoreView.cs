using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;

        public void UpdateCurrentScore(int score) => _currentScoreText.text = score.ToString();
        public void UpdateBestScore(int bestScore) => _bestScoreText.text = bestScore.ToString();
    }
}