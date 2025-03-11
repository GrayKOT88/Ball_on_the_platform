using UnityEngine;

namespace NewScript
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        private Rigidbody _enemyRb;
        private Transform _playerTransform;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
            _playerTransform = GameObject.Find("Player").transform;
        }

        private void Update()
        {
            Vector3 lookDirection = (_playerTransform.position - transform.position).normalized;
            _enemyRb.AddForce(lookDirection * _speed);
        }
    }
}