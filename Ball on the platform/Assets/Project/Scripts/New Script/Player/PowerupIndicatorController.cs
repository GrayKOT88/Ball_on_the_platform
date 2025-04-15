using System.Collections;
using UnityEngine;

namespace NewScript
{
    public class PowerupIndicatorController : MonoBehaviour
    {
        private GameSettings _settings;
        private GameObject _powerupIndicator;
        private Rigidbody _playerRb;
        private bool _hasPowerup = false;        

        public void Initialize(GameSettings settings, GameObject powerupIndicator, Rigidbody playerRb)
        {
            _settings = settings;
            _powerupIndicator = powerupIndicator;
            _playerRb = playerRb;

            EventBus.Subscribe<PowerupCollectedEvent>(OnPowerupIndicator);
        }

        private void FixedUpdate()
        {
            if (_playerRb.velocity.sqrMagnitude > 0.1f)
            {
                _powerupIndicator.transform.position = transform.position + _settings.IndicatorPosition;
            }
        }

        private void OnPowerupIndicator(PowerupCollectedEvent evt)
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

        private void OnDestroy()
        {
            EventBus.Unsubscribe<PowerupCollectedEvent>(OnPowerupIndicator);
        }
    }
}