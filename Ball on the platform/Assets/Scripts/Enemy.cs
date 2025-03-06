using UnityEngine;

namespace Script
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 3f;
        private Rigidbody enemyRd;
        private GameObject player;

        private void Start()
        {
            enemyRd = GetComponent<Rigidbody>();
            player = GameObject.Find("Player");
        }
        private void Update()
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRd.AddForce(lookDirection * speed);
            if(transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }
    }
}