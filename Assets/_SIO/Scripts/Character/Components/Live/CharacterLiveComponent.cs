using System;
using UnityEngine;

public class CharacterLiveComponent : ILiveComponent
{
    private Character selfCharacter;
    private float currentHealth;
    private float maxHealth;
    private bool isAlive = false;

    public event Action<Character> OnCharacterDeath;
    public event Action<Character> OnCharacterHealthChange;

    public float MaxHealth => maxHealth;
    public float Health
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            if (currentHealth <= 0) SetDeath();
        }
    }

    public bool IsAlive => isAlive;

    public void Initialize(Character selfCharacter, CharacterData characterData)
    {
        this.selfCharacter = selfCharacter;
        maxHealth = characterData.MaxHealth;
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void SetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Get damage = {damage}, Current health = {Health}");
    }

    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        isAlive = false;
    }
}
