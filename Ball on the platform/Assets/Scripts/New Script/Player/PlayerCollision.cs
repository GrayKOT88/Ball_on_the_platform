using UnityEngine;

namespace NewScript
{
    public class PlayerCollision : MonoBehaviour
    {
        private PowerupController _powerupController;
        private float _powerupStrength = 15f;

        private void Start()
        {
            _powerupController = GetComponent<PowerupController>();
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
            enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
        }
    }
}