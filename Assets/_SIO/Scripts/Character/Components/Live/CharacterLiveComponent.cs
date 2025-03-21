using System;
using UnityEngine;

public class CharacterLiveComponent : ILiveComponent
{
    private Character selfCharacter;
    private float currentHealth;
    private const float DefaultMaxHealth = 50f;

    public event Action<Character> OnCharacterDeath;

    public float MaxHealth { get => DefaultMaxHealth; set { } }
    public float Health
    {
        get => currentHealth;
        set
        {
            currentHealth = Mathf.Clamp(value, 0, DefaultMaxHealth);
            if (currentHealth <= 0) SetDeath();
        }
    }

    public CharacterLiveComponent()
    {
        currentHealth = DefaultMaxHealth;
    }

    public void SetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Get damage = {damage}");
    }

    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("Death!");
    }

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
}