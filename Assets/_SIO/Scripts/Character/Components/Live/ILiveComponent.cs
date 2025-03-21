using System;

public interface ILiveComponent : ICharacterComponent
{
    public event Action<Character> OnCharacterDeath;
    public float MaxHealth { get; set; }

    public float Health { get; set; }

    public void SetDamage(float damage);
}
