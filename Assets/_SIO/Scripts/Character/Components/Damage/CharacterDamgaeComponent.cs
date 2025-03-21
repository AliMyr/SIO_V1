public class CharacterDamageComponent : IDamageComponent
{
    private readonly float damage;

    public float Damage => damage;

    public CharacterDamageComponent(float damage = 10f)
    {
        this.damage = damage;
    }

    public void MakeDamage(Character characterTarget)
    {
        characterTarget?.LiveComponent?.SetDamage(damage);
    }
}