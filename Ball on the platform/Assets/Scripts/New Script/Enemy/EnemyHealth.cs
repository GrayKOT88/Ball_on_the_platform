using System;
using UnityEngine;

namespace NewScript
{
    public class EnemyHealth : MonoBehaviour
    {
        private float _fallThreshold = -5f;

        public event Action<GameObject> OnEnemyDestroyed;

        private void Update()
        {
            if (transform.position.y < _fallThreshold)
            {
                OnEnemyDestroyed?.Invoke(gameObject);
                Destroy(gameObject);
            }
        }
    }
}