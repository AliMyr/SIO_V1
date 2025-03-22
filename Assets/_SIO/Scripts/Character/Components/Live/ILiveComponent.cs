using System;

public interface ILiveComponent : ICharacterComponent
{
    event Action<Character> OnCharacterDeath;
    event Action<Character> OnCharacterHealthChange;

    float MaxHealth { get; set; }
    float Health { get; set; }
    void SetDamage(float damage);
}