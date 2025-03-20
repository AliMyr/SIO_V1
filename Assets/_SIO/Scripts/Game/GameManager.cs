using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private CharacterFactory characterFactory;

    private ScoreSystem scoreSystem;

    private bool isGameActive;
    
    public static GameManager Instance { get; private set; }

    public CharacterFactory CharacterFactory => characterFactory;

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else 
        { 
            Destroy(this.gameObject);
        }
    }

    private void Initialize()
    {
        scoreSystem = new ScoreSystem();
        isGameActive = false;
    }

    public void StartGame()
    {
        if (isGameActive)
        {
            return;
        }

        Character player = characterFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.Initialize();

        isGameActive=true;
    }
}
