using UnityEngine;

namespace NewScript
{
    public class PlayerMovement : MonoBehaviour
    {
        private GameSettings _settings;
        private GameManager _gameManager;
        private Transform _focalPoint;
        private Rigidbody _playerRb;

        public void Initialize(GameSettings settings, GameManager gameManager, Transform focalPoint, Rigidbody playerRb)
        {
            _settings = settings;
            _gameManager = gameManager;
            _focalPoint = focalPoint;
            _playerRb = playerRb;
        }
        
        private void FixedUpdate()
        {
            if (_gameManager.IsGameActive)
            {
                float forwardInput = Input.GetAxis("Vertical");
                _playerRb.AddForce(_focalPoint.transform.forward * _settings.PlayerSpeed * forwardInput);
                if (transform.position.y < _settings.LowerBoundDestroy)
                {
                    _gameManager.EndGame();
                    Destroy(gameObject);
                }
            }
        }
    }
}