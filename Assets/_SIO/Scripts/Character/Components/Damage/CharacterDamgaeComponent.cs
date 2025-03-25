public class CharacterDamageComponent : IDamageComponent
{
    private float damage;

    public float Damage => damage;

    public void Initialize(Character selfCharacter, CharacterData characterData)
    {
        damage = characterData.Damage;
    }

    public void MakeDamage(Character characterTarget)
    {
        characterTarget?.LiveComponent?.SetDamage(damage);
        characterTarget.AnimationComponent.SetTrigger("AttackTrigger");
    }
}
