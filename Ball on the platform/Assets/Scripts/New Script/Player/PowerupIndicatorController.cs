using System.Collections;
using UnityEngine;

namespace NewScript
{
    public class PowerupIndicatorController : MonoBehaviour
    {        
        [SerializeField] private GameObject _powerupIndicator;
        private bool _hasPowerup = false;
        private float _powerupDuration = 7f;

        private void Start()
        {
            Powerup.OnPowerup += OnPowerupIndicator;
        }

        private void Update()
        {            
            _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.7f, 0);
        }

        private void OnPowerupIndicator()
        {
            _hasPowerup = true;
            _powerupIndicator.SetActive(true);                 
            StartCoroutine(PowerupCountdownRoutine());
        }
        
        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(_powerupDuration);
            _hasPowerup = false;
            _powerupIndicator.SetActive(false);
        }

        public bool HasPowerup()
        {
            return _hasPowerup;
        }
    }
}