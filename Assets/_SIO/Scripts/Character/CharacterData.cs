using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private int scoreCost = 10;
    [SerializeField] private float timeBetweenAttacks = 1f;

    private float timeBetweenAttackCounter;

    public float Speed => speed;
    public float MaxHealth => maxHealth;
    public float Damage => damage;
    public int ScoreCost => scoreCost;
    public float TimeBetweenAttacks => timeBetweenAttacks;
    public float TimeBetweenAttackCounter
    {
        get => timeBetweenAttackCounter;
        set => timeBetweenAttackCounter = value;
    }
}
