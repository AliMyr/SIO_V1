using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public IHealthComponent HealthComponent 
    {  
        get; 
        protected set; 
    }

    public virtual void Initialize() 
    {
        Debug.Log("Init");
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
