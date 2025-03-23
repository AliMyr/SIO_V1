using UnityEngine;

public interface IMovable : ICharacterComponent
{
    public float Speed { get; }

    public void Move(Vector3 direction);

    public void Rotation(Vector3 direction);
}
