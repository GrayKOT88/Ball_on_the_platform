using UnityEngine;

namespace NewScript
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        private Rigidbody _enemyRd;
        private GameObject _player;

        private void Start()
        {
            _enemyRd = GetComponent<Rigidbody>();
            _player = GameObject.Find("Player");
        }
        private void Update()
        {
            Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
            _enemyRd.AddForce(lookDirection * _speed);
            if(transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}