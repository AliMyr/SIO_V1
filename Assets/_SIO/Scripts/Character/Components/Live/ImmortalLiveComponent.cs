using System;
using UnityEngine;

public class ImmortalLiveComponent : ILiveComponent
{
    public bool IsAlive => true;

    float ILiveComponent.MaxHealth { get => 1; }
    float ILiveComponent.Health { get => 1;}

    public event Action<Character> OnCharacterDeath;
    public event Action<Character> OnCharacterHealthChange;

    public void Initialize(Character selfCharacter, CharacterData characterData)
    {
        throw new NotImplementedException();
    }

    public void SetDamage(float damage)
    {
        Debug.Log("I am Aboba");
    }
}
