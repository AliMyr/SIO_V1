using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    private float health = 100;
    private float maxHealth = 100;

    public float Health 
    {
        get 
        { 
            return health; 
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
        //throw new NotImplementedException();
    }

    public void SetDamage(float damage)
    {
        Debug.Log("I am immortal");
    }

}
