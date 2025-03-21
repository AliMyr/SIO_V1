using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private int scoreCost = 10;
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private CharacterController characterController;

    private float timeBetweenAttackCounter;

    public float DefaultSpeed => speed;
    public float MaxHealth => maxHealth;
    public float Damage => damage;
    public int ScoreCost => scoreCost;
    public float TimeBetweenAttacks => timeBetweenAttacks;
    public Transform CharacterTransform => characterTransform;
    public CharacterController CharacterController => characterController;
    public float TimeBetweenAttackCounter
    {
        get => timeBetweenAttackCounter;
        set => timeBetweenAttackCounter = value;
    }
}