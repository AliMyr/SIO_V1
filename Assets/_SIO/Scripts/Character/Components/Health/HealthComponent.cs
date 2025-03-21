using System;
using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private Character selfCharacter;
    private float health = 25;
    private float maxHealth = 100;

    public float Health 
    {
        get 
        {
            return health;
        }
        private set 
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
            if (health == 0)
            {
                SetDeath();
            }
        }
    }


    public float MaxHealth 
    {
        get 
        {
            return maxHealth; 
        }   
    }

    public event Action<Character> OnCharacterDeath;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }

    public void SetDamage(float damage)
    {
        Health -= damage;
    }

    private void SetDeath() 
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("Death");
    }
}
