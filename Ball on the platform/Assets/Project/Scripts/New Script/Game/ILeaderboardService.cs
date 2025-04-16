namespace NewScript 
{
    public interface ILeaderboardService
    {
        void SubmitScore(int score);
        void SubmitTime(int time);
    }
}