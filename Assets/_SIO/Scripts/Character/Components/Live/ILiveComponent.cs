using System;

public interface ILiveComponent : ICharacterComponent
{
    event Action<Character> OnCharacterDeath;
    event Action<Character> OnCharacterHealthChange;

    float MaxHealth { get;}
    float Health { get;}
    bool IsAlive { get;}
    void SetDamage(float damage);
}