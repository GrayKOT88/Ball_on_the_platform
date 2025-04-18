using Zenject;

namespace NewScript 
{
    public class StartButton : AnimatedButton
    {       
        [Inject] private GameManager _gameManager;

        protected override void OnButtonClick() => _gameManager.StartGame();
    }
}