using UnityEngine;

namespace NewScript
{
    public class PlayerCollision : MonoBehaviour
    {
        private GameSettings _settings;
        private PowerupIndicatorController _powerupController;

        public void Initialize(GameSettings settings, PowerupIndicatorController powerupIndicatorController)
        {
            _settings = settings;
            _powerupController = powerupIndicatorController;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _powerupController.HasPowerup())
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.transform.position - transform.position;
                ICommand command = new ApplyForceCommand(enemyRb, awayFromPlayer * _settings.PowerupStrength);
                command.Execute();                
            }
        }
    }
}