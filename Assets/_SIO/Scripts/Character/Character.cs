using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private CharacterController characterController;

    public virtual Character CharacterTarget { get; }
    public CharacterType CharacterType => characterType;
    public CharacterData CharacterData => characterData;
    public CharacterController CharacterController => characterController;
    public Transform CharacterTransform => transform;

    public IMovable MovableComponent { get; private set; }
    public ILiveComponent LiveComponent { get; private set; }
    public IDamageComponent DamageComponent { get; private set; }

    public virtual void Initialize()
    {
        MovableComponent = new CharacterMovementComponent();
        LiveComponent = new CharacterLiveComponent();
        DamageComponent = new CharacterDamageComponent();

        MovableComponent.Initialize(this, characterData);
        LiveComponent.Initialize(this, characterData);
        DamageComponent.Initialize(this, characterData);
    }

    public abstract void Update();

    public void Enqueue(Character character)
    {

    }
}
