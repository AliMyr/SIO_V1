using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    public IHealthComponent HealthComponent 
    {  
        get; 
        protected set; 
    }

    public IMovementComponent MovementComponent 
    {
        get; 
        protected set; 
    }

    public virtual void Initialize() 
    {
        MovementComponent = new DefaultMovementComponent();
        MovementComponent.Initialize(characterData);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
