using System;
using UnityEngine;

public class CharacterLiveComponent : ILiveComponent
{
    private Character selfCharacter;
    private float currentHealth;
    private float maxHealth;

    public event Action<Character> OnCharacterDeath;

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = Mathf.Max(0, value);
    }

    public float Health
    {
        get => currentHealth;
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            if (currentHealth <= 0) SetDeath();
        }
    }

    public CharacterLiveComponent(float maxHealth = 50f)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public void SetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Get damage = {damage}, Current health = {Health}");
    }

    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("Character died!");
    }

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }
}