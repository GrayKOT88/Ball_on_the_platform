using NewScript;
using System;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    public event Action OnEnemyDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyPool.ReturnEnemy(collision.gameObject.GetComponent<Enemy>());
            OnEnemyDestroyed?.Invoke();
        }
    }
}
