using System.Collections;
using UnityEngine;
using Zenject;

namespace NewScript
{
    public class PowerupIndicatorController : MonoBehaviour
    {
        [Inject] private GameObject _powerupIndicator;
        [Inject] private GameSettings _settings;
        private bool _hasPowerup = false;
        private Vector3 _indicatorPosition = new Vector3(0, -0.7f, 0);
        private Rigidbody _playerRb;

        private void Start()
        {
            Powerup.OnPowerup += OnPowerupIndicator;
            _playerRb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_playerRb.velocity.sqrMagnitude > 0.1f)
            {
                _powerupIndicator.transform.position = transform.position + _indicatorPosition;
            }
        }

        private void OnPowerupIndicator()
        {
            _hasPowerup = true;
            _powerupIndicator.SetActive(true);                 
            StartCoroutine(PowerupCountdownRoutine());
        }
        
        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(_settings.PowerupDuration);
            _hasPowerup = false;
            _powerupIndicator.SetActive(false);
        }

        public bool HasPowerup()
        {
            return _hasPowerup;
        }
    }
}