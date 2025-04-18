using Zenject;

namespace NewScript 
{
    public class RestartButton : AnimatedButton
    {
        [Inject] private GameManager _gameManager;

        protected override void OnButtonClick() => _gameManager.RestartGame();
    }
}