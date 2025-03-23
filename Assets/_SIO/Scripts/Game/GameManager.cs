using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharacterFactory characterFactory;
    [SerializeField] private WindowsService windowsService;

    private ScoreSystem scoreSystem;
    private float gameSessionTime;
    private float timeBetweenEnemySpawn;
    private bool isGameActive;

    public static GameManager Instance { get; private set; }
    public CharacterFactory CharacterFactory => characterFactory;
    public WindowsService WindowsService => windowsService;
    public ScoreSystem ScoreSystem => scoreSystem;
    public float GameSessionTime => gameSessionTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    private void Initialize()
    {
        scoreSystem = new ScoreSystem();
        isGameActive = false;
        windowsService.Initialize();
    }

    public void StartGame()
    {
        if (isGameActive) return;

        var player = characterFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        player.Initialize();
        player.LiveComponent.OnCharacterDeath += CharacterDeathHandler;

        gameSessionTime = 0;
        timeBetweenEnemySpawn = gameData.TimeBetweenEnemySpawn;
        scoreSystem.startGame();
        isGameActive = true;
    }

    private void Update()
    {
        if (!isGameActive) return;

        float deltaTime = Time.deltaTime;
        gameSessionTime += deltaTime;
        timeBetweenEnemySpawn -= deltaTime;

        if (timeBetweenEnemySpawn <= 0)
        {
            SpawnEnemy();
            timeBetweenEnemySpawn = gameData.TimeBetweenEnemySpawn;
        }

        if (gameSessionTime >= gameData.SessionTimeSecond)
        {
            GameVictory();
        }
    }

    private void CharacterDeathHandler(Character deathCharacter)
    {
        if (deathCharacter == null) return;

        deathCharacter.LiveComponent.OnCharacterDeath -= CharacterDeathHandler;
        deathCharacter.gameObject.SetActive(false);
        characterFactory.ReturnCharacter(deathCharacter);

        switch (deathCharacter.CharacterType)
        {
            case CharacterType.Player:
                GameOver();
                break;
            case CharacterType.DefaultEnemy:
                scoreSystem.AddScore(deathCharacter.CharacterData.ScoreCost);
                break;
        }
    }

    private void SpawnEnemy()
    {
        var enemy = characterFactory.GetCharacter(CharacterType.DefaultEnemy);
        Vector3 playerPos = characterFactory.Player.transform.position;
        float offsetX = Random.Range(gameData.MinSpawnOffset, gameData.MaxSpawnOffset) * (Random.value > 0.5f ? 1 : -1);
        float offsetZ = Random.Range(gameData.MinSpawnOffset, gameData.MaxSpawnOffset) * (Random.value > 0.5f ? 1 : -1);
        enemy.transform.position = new Vector3(playerPos.x + offsetX, 0, playerPos.z + offsetZ);
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
        enemy.LiveComponent.OnCharacterDeath += CharacterDeathHandler;
    }

    private void GameVictory()
    {
        scoreSystem.EndGame();
        WindowsService.HideWindow<GameplayWindow>(true);
        WindowsService.ShowWindow<VictoryWindow>(false);
        Debug.Log("Victory");
        isGameActive = false;
    }

    private void GameOver()
    {
        scoreSystem.EndGame();
        WindowsService.HideWindow<GameplayWindow>(true);
        WindowsService.ShowWindow<DefeatWindow>(false);
        Debug.Log("Defeat");
        isGameActive = false;
    }
}