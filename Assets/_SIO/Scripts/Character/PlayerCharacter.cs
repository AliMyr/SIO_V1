using UnityEngine;

public class PlayerCharacter : Character
{
    private Vector3 movementVector;

    public override Character CharacterTarget
    {
        get
        {
            Character target = null;
            float minDistanceSqr = float.MaxValue;
            var characters = GameManager.Instance.CharacterFactory.ActiveCharacter;

            foreach (var character in characters)
            {
                if (character.CharacterType == CharacterType.Player) continue;
                float distanceSqr = (character.transform.position - transform.position).sqrMagnitude;
                if (distanceSqr < minDistanceSqr)
                {
                    target = character;
                    minDistanceSqr = distanceSqr;
                }
            }
            return target;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        MovableComponent.Initialize(CharacterTarget, CharacterData);
    }

    public override void Update()
    {
        if (!LiveComponent.IsAlive || !GameManager.Instance.IsGameActive) return;

        movementVector.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movementVector.Normalize();

        MovableComponent.Move(movementVector);

        if (CharacterTarget != null)
        {
            Vector3 rotationDirection = CharacterTarget.transform.position - transform.position;
            MovableComponent.Rotation(rotationDirection);

            if (Input.GetButtonDown("Jump") && CharacterData.TimeBetweenAttackCounter <= 0)
            {
                DamageComponent?.MakeDamage(CharacterTarget);
                CharacterData.TimeBetweenAttackCounter = CharacterData.TimeBetweenAttacks;
            }
        }
        else
        {
            MovableComponent.Rotation(movementVector);
        }

        if (CharacterData.TimeBetweenAttackCounter > 0)
            CharacterData.TimeBetweenAttackCounter -= Time.deltaTime;
    }
}
