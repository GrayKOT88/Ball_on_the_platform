using UnityEngine;
using Zenject;

namespace NewScript
{
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private GameSettings _settings;
        [Inject] private GameManager _gameManager;
        [SerializeField] private Transform _focalPoint;
        private Rigidbody _playerRb;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();            
        }

        private void FixedUpdate()
        {
            if (_gameManager.IsGameActiv)
            {
                float forwardInput = Input.GetAxis("Vertical");
                _playerRb.AddForce(_focalPoint.transform.forward * _settings.PlayerSpeed * forwardInput);
                if (transform.position.y < _settings.LowerBoundDestroy)
                {
                    _gameManager.EndGame();                    
                }
            }
        }
    }
}