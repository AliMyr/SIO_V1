using UnityEngine;

public class AttackComponent : IAttackComponent
{
    private CharacterData characterData;
    private float damage;
    private float attackRange;

    public float Damage 
    { 
        get => damage; 
        set
        {
            if (value < 0)
                damage = 0;
            else
                damage = value;
        }
    }
    public float AttackRange 
    { 
        get => attackRange; 
        set
        {
            if (value < 0)
                attackRange = 0;
            else
                attackRange = value;
        }
    }

    public void Initialize(CharacterData characterData) 
    {
        this.characterData = characterData;
        Damage = characterData.Damage;
        AttackRange = characterData.AttackRange;
    }

    public void MakeDamage(Character attackTarget)
    {
        if (Vector3.Distance(characterData.CharacterTransform.position, attackTarget.transform.position) <= attackRange) 
            attackTarget.HealthComponent.SetDamage(Damage);
    }

}
