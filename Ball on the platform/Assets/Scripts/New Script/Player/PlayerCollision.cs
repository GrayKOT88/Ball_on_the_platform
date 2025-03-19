using UnityEngine;

namespace NewScript
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        private PowerupIndicatorController _powerupController;        

        private void Start()
        {
            _powerupController = GetComponent<PowerupIndicatorController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _powerupController.HasPowerup())
            {
                ApplyForceToEnemy(collision.gameObject);
            }
        }

        private void ApplyForceToEnemy(GameObject enemy)
        {
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemy.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * _gameSettings.PowerupStrength, ForceMode.Impulse);
        }
    }
}