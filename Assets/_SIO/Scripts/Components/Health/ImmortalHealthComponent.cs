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


    public void SetDamage(float damage)
    {
        Debug.Log("I am immortal");
    }

}
