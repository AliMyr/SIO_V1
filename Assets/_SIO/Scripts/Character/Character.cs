using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] private CharacterData characterData;

    public virtual Character CharacterTarget { get; }
    public CharacterType CharacterType => characterType;
    public CharacterData CharacterData => characterData;
    public IMovable MovableComponent { get; protected set; }
    public ILiveComponent LiveComponent { get; protected set; }
    public IDamageComponent DamageComponent { get; protected set; }

    public virtual void Initialize()
    {
        MovableComponent = new CharacterMovementComponent();
        LiveComponent = new CharacterLiveComponent();
        DamageComponent = new CharacterDamageComponent();

        MovableComponent.Initialize(CharacterTarget, characterData);
        LiveComponent.Initialize(CharacterTarget, characterData);
        DamageComponent.Initialize(CharacterTarget, characterData);
    }

    public abstract void Update();

    public void Enqueue(Character character)
    {

    }
}
