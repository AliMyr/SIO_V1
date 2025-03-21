using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private AiState currentState;
    private const float AttackRangeSqr = 9f;

    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {
        if (currentState != AiState.MoveToTarget) return;

        Vector3 direction = CharacterTarget.transform.position - transform.position;
        float distanceSqr = direction.sqrMagnitude;
        direction.Normalize();

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);

        if (distanceSqr < AttackRangeSqr && characterData.TimeBetweenAttackCounter <= 0)
        {
            DamageComponent?.MakeDamage(CharacterTarget);
            characterData.TimeBetweenAttackCounter = characterData.TimeBetweenAttacks;
        }

        if (characterData.TimeBetweenAttackCounter > 0)
            characterData.TimeBetweenAttackCounter -= Time.deltaTime;
    }
}