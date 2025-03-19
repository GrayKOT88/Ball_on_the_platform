using UnityEngine;

namespace NewScript
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 2f;
        private Rigidbody _playerRb;
        private Transform _focalPoint;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("Focal Point").transform;
        }

        private void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            _playerRb.AddForce(_focalPoint.transform.forward * _playerSpeed * forwardInput);
        }
    }
}