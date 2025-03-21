using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] protected CharacterData characterData;

    public virtual Character CharacterTarget { get; }
    public CharacterType CharacterType => characterType;
    public CharacterData CharacterData => characterData;
    public IMovable MovableComponent { get; protected set; }
    public ILiveComponent LiveComponent { get; protected set; }
    public IDamageComponent DamageComponent { get; protected set; }

    public virtual void Initialize()
    {
        MovableComponent = new CharacterMovementComponent();
        LiveComponent = new CharacterLiveComponent(characterData?.MaxHealth ?? 50f);
        DamageComponent = new CharacterDamageComponent(characterData?.Damage ?? 10f);

        MovableComponent.Initialize(characterData);
        LiveComponent.Initialize(this);
    }

    public abstract void Update();

    public void Enqueue(Character character)
    {

    }
}
