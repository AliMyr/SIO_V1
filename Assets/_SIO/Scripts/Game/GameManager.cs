using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private CharacterFactory characterFactory;
    
    public static GameManager Instance { get; private set; }

    public CharacterFactory CharacterFactory => characterFactory;

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
        }
        else 
        { 
            Destroy(this.gameObject);
        }
    }
}
