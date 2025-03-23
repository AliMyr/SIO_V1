public interface IDamageComponent : ICharacterComponent
{
    float Damage { get; }
    void MakeDamage(Character characterTarget);
}