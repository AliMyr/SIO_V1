using System;
using UnityEngine;

public class CharacterLiveComponent : ILiveComponent
{
    private Character selfCharacter;
    private float currentHealth;
    private float maxHealth;
    private bool isAlive;

    public event Action<Character> OnCharacterDeath;
    public event Action<Character> OnCharacterHealthChange;

    public float MaxHealth => maxHealth;
    public float Health => currentHealth;
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
        if (!isAlive) return;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth <= 0)
        {
            SetDeath();
        }
    }

    private void SetDeath()
    {
        isAlive = false;
        OnCharacterDeath?.Invoke(selfCharacter);
    }
}
