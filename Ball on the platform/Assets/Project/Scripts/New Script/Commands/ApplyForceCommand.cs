using UnityEngine;

namespace NewScript
{
    public class ApplyForceCommand : ICommand
    {
        private Rigidbody _enemyRb;
        private Vector3 _force;

        public ApplyForceCommand(Rigidbody enemyRb, Vector3 force)
        {
            _enemyRb = enemyRb;
            _force = force;
        }

        public void Execute()
        {
            _enemyRb.AddForce(_force, ForceMode.Impulse);
        }
    }
}