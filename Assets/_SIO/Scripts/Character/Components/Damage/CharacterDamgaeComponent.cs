public class CharacterDamageComponent : IDamageComponent
{
    private const float DefaultDamage = 10f;
    public float Damage => DefaultDamage;

    public void MakeDamage(Character characterTarget)
    {
        characterTarget?.LiveComponent?.SetDamage(DefaultDamage);
    }
}