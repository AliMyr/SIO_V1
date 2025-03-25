using UnityEngine;

public class CharacterMovementComponent : IMovable
{
    private Character character;
    private float speed;

    public float Speed => speed;

    public void Initialize(Character selfCharacter, CharacterData characterData)
    {
        character = selfCharacter;
        speed = characterData.Speed;
    }

    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
        {
            character.AnimationComponent.SetValue("Movement", 0);
            return;
        }

        Vector3 move = direction.normalized * speed * Time.deltaTime;
        character.CharacterController.Move(move);

        character.AnimationComponent.SetValue("Movement", move.magnitude / Time.deltaTime);
    }


    public void Rotation(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        character.CharacterTransform.rotation = targetRotation;
    }
}
