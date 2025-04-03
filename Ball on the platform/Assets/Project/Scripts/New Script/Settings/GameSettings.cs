using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Player")]
    public float PlayerSpeed = 2f;
    public float PowerupStrength = 15f;
    public float PowerupDuration = 7f;
    public Vector3 IndicatorPosition = new Vector3(0, -0.7f, 0);
    [Space]
    [Header("Enemy")]
    public float EnemySpeed = 1f;
    [Space]
    [Header("Player/Enemy")]
    public float LowerBoundDestroy = -10f;
    [Space]
    [Header("Spawn")]
    public float SpawnRange = 9f;
    [Space]
    [Header("Camera")]
    public float RotationSpeed = 50f;
    [Space]
    [Header("Object Pool")]
    public int EnemyPoolSize = 5;
    public int PowerupPoolSize = 5;
}
