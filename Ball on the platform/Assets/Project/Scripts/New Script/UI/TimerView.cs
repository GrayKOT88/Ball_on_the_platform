using TMPro;
using UnityEngine;

namespace NewScript 
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _bestTimeText;

        public void UpdateTimerDisplay(float currentTime)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void UpdateBestTimeDisplay(float bestTime)
        {
            int minutes = Mathf.FloorToInt(bestTime / 60);
            int seconds = Mathf.FloorToInt(bestTime % 60);
            _bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}