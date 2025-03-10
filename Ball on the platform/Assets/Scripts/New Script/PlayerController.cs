using System.Collections;
using UnityEngine;

namespace NewScript
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _playerRb;
        private GameObject _focalPoint;
        private float _powerupStrength = 15f;
        private bool _hasPowerup = false;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private GameObject _powerupIndicator;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("Focal Point");
        }
        private void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            _playerRb.AddForce(_focalPoint.transform.forward * _speed * forwardInput);
            _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                _hasPowerup = true;
                _powerupIndicator.SetActive(true);
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }
        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            _hasPowerup = false;
            _powerupIndicator.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
            }
        }
    }
}