using UnityEngine;

namespace NewScript
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * _rotationSpeed * Time.deltaTime);
        }
    }
}