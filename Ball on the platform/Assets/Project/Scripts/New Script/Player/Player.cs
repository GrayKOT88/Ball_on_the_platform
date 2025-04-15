using UnityEngine;
using Zenject;

namespace NewScript
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _powerupIndicator;        
        [SerializeField] private Transform _focalPoint;
        [Inject] private GameSettings _settings;
        [Inject] private GameManager _gameManager;        
        private Rigidbody _playerRb;

        private void Start()
        {            
            _playerRb = GetComponent<Rigidbody>();

            var collision = GetComponent<PlayerCollision>();
            var movement = GetComponent<PlayerMovement>();
            var powerupIndicatorController = GetComponent<PowerupIndicatorController>();

            collision.Initialize(_settings, powerupIndicatorController);
            movement.Initialize(_settings, _gameManager, _focalPoint, _playerRb);
            powerupIndicatorController.Initialize(_settings, _powerupIndicator, _playerRb);
        }
    }
}