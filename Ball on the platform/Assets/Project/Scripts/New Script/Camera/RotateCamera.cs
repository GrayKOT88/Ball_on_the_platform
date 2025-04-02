using UnityEngine;
using Zenject;

namespace NewScript
{
    public class RotateCamera : MonoBehaviour
    {
        [Inject] private GameSettings _settings;
        [Inject] private GameManager _gameManager;

        private void Update()
        {
            if (_gameManager.IsGameActiv)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.up, -horizontalInput * _settings.RotationSpeed * Time.deltaTime);
            }
        }
    }
}