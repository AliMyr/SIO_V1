using UnityEngine;

public interface IAttackComponent
{
    float Damage { get; set; }
    float AttackRange { get; set; }

    void Initialize(CharacterData characterData);

    void MakeDamage(Character attackTarget);


}
