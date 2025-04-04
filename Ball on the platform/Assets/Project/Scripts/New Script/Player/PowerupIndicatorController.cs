using System.Collections;
using UnityEngine;
using Zenject;

namespace NewScript
{
    public class PowerupIndicatorController : MonoBehaviour
    {
        [Inject] private GameSettings _settings;
        [SerializeField] private GameObject _powerupIndicator;
        private bool _hasPowerup = false;        
        private Rigidbody _playerRb;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();            
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