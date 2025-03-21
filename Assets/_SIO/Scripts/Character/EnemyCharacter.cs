using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCharacter : Character
{
    [SerializeField]
    private AiState aiState;

    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();

        AttackComponent = new AttackComponent();
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0)
            return;

        switch (aiState) 
        {
            case AiState.None:
                return;
            case AiState.Idle:
                return;
            case AiState.MoveToTarget:
                Vector3 moveDirection = CharacterTarget.transform.position - transform.position;
                moveDirection.Normalize();

                MovementComponent.Move(moveDirection);
                MovementComponent.Rotation(moveDirection);

                AttackComponent.MakeDamage(CharacterTarget);

                return;
        }
    }

}
