using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();
    }

    protected override void Update()
    {
        
    }

}
