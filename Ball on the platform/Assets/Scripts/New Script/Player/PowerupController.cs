using System.Collections;
using UnityEngine;

namespace NewScript
{
    public class PowerupController : MonoBehaviour
    {
        [SerializeField] private PowerupPool _powerupPool;
        [SerializeField] private GameObject _powerupIndicator;
        private bool _hasPowerup = false;
        private float _powerupDuration = 7f;

        private void Update()
        {            
            _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.7f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                _hasPowerup = true;
                _powerupIndicator.SetActive(true);
                //Destroy(other.gameObject);
                ReturnPowerupToPool(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        private void ReturnPowerupToPool(GameObject powerup)
        {            
            if (_powerupPool != null)
            {
                _powerupPool.ReturnPowerup(powerup.GetComponent<Powerup>());
            }
            else
            {
                Destroy(powerup);
            }
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