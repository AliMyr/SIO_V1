using UnityEngine;

public class HealthComponent : IHealthComponent
{
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

    public void SetDamage(float damage)
    {
        Health -= damage;
    }

    private void SetDeath() 
    {
        Debug.Log("Death");
    }
}
