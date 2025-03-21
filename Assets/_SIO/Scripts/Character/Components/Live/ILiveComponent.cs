using System;

public interface ILiveComponent : ICharacterComponent
{
    event Action<Character> OnCharacterDeath;
    float MaxHealth { get; set; }
    float Health { get; set; }
    void SetDamage(float damage);
}