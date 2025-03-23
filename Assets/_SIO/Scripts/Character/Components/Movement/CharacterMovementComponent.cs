using UnityEngine;

public class CharacterMovementComponent : IMovable
{
    private float speed;

    public float Speed => speed;

    public void Initialize(Character selfCharacter, CharacterData characterData)
    {
        speed = characterData.Speed;
    }

    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        Vector3 move = direction.normalized * speed * Time.deltaTime;
        CharacterController characterController = GameManager.Instance.CharacterFactory.Player.CharacterData.CharacterController;
        characterController.Move(move);
    }

    public void Rotation(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        GameManager.Instance.CharacterFactory.Player.CharacterData.CharacterTransform.rotation = targetRotation;
    }
}
