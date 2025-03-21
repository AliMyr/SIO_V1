using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterType characterType;
    [SerializeField]
    protected CharacterData characterData;

    public virtual Character CharacterTarget { get; }
    public CharacterData CharacterData {  get { return characterData; } }
    public CharacterType CharacterType {  get { return characterType; } }
    public IHealthComponent HealthComponent {  get; protected set; }
    public IMovementComponent MovementComponent {   get; protected set; }
    public IAttackComponent AttackComponent{   get; protected set; }


    public virtual void Initialize() 
    {
        MovementComponent = new DefaultMovementComponent();
        MovementComponent.Initialize(characterData);

        AttackComponent = new AttackComponent();
        AttackComponent.Initialize(characterData);
    }

    protected abstract void Update();
}
