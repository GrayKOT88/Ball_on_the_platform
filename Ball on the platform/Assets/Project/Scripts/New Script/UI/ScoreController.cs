namespace NewScript 
{
    public class ScoreController
    {
        private ScoreModel _model;
        private ScoreView _view;

        public ScoreController(ScoreModel model, ScoreView view)
        {
            _model = model;
            _view = view;

            // Принудительно обновляем View            
            _view.UpdateBestScore(_model.BestScore);

            // Подписка на события
            _model.OnScoreUpdated += _view.UpdateCurrentScore;           
            Enemy.OnEnemyDestroyed += _model.IncrementScore;
        }

        public void SaveBestScore() => _model.SaveBestScore();
    }
}