using UnityEngine;
using YG;

namespace NewScript 
{
    public class YGLeaderboardAdapter : ILeaderboardService
    {
        public void SubmitScore(int score)
        {
            if (!YandexGame.SDKEnabled)
            {
                Debug.LogWarning("Yandex SDK not ready! Score not submitted.");
                return;
            }
            YandexGame.NewLeaderboardScores("LeaderboardScore", score);
        }

        public void SubmitTime(int time)
        {
            if (!YandexGame.SDKEnabled)
            {
                Debug.LogWarning("Yandex SDK not ready! Score not submitted.");
                return;
            }
            YandexGame.NewLeaderboardScores("LeaderboardTime", time);
        }
    }
}