using UnityEngine;

namespace NewScript
{
    public class RotateCamera : MonoBehaviour
    {        
        [SerializeField] private GameSettings _gameSettings;

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * _gameSettings.RotationSpeed * Time.deltaTime);
        }
    }
}