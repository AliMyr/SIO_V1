using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private AiState currentState;

    public override Character CharacterTarget =>
        GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();

        MovableComponent.Initialize(characterData);
        LiveComponent.Initialize(this);
    }

    public override void Update()
    {
        switch (currentState)
        {
            case AiState.None:
                break;

            case AiState.MoveToTarget:
                Vector3 direction = CharacterTarget.transform.position - transform.position;
                direction.Normalize();

                MovableComponent.Move(direction);
                MovableComponent.Rotation(direction);

                if (Vector3.Distance(CharacterTarget.transform.position, transform.position) < 3
                    && characterData.TimeBetweenAttackCounter <= 0)
                {
                    DamageComponent.MakeDamage(CharacterTarget);
                    characterData.TimeBetweenAttackCounter = characterData.TimeBetweenAttacks;
                }

                if (characterData.TimeBetweenAttackCounter > 0)
                    characterData.TimeBetweenAttackCounter -= Time.deltaTime;

                break;
        }
    }
}
