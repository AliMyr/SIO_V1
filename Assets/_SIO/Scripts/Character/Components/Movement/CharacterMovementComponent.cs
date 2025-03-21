using UnityEngine;

public class CharacterMovementComponent : IMovable
{
    private CharacterData characterData;
    private float speed;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0, value);
    }

    public void Initialize(CharacterData characterData)
    {
        this.characterData = characterData;
        speed = characterData.DefaultSpeed;
    }

    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Vector3 move = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        characterData.CharacterController.Move(move * Speed * Time.deltaTime);
    }

    public void Rotation(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float currentAngle = characterData.CharacterTransform.eulerAngles.y;
        float smoothVelocity = 0f;
        float angle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref smoothVelocity, 0.1f);
        characterData.CharacterTransform.rotation = Quaternion.Euler(0, angle, 0);
    }
}