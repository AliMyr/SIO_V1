using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharacterFactory characterFactory;
    [SerializeField] private WindowsService windowsService;

    private ScoreSystem scoreSystem;
    private float gameSessionTime;
    private float enemySpawnTimer;
    private bool isGameActive;

    public static GameManager Instance { get; private set; }
    public CharacterFactory CharacterFactory => characterFactory;
    public WindowsService WindowsService => windowsService;
    public ScoreSystem ScoreSystem => scoreSystem;
    public float GameSessionTime => gameSessionTime;
    public bool IsGameActive => isGameActive;

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

        isGameActive = true;
        gameSessionTime = 0;
        enemySpawnTimer = gameData.TimeBetweenEnemySpawn;
        scoreSystem.StartGame();

        var player = characterFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.LiveComponent.OnCharacterDeath += OnCharacterDeath;
    }

    private void Update()
    {
        if (!isGameActive) return;

        float deltaTime = Time.deltaTime;
        gameSessionTime += deltaTime;
        enemySpawnTimer -= deltaTime;

        if (enemySpawnTimer <= 0)
        {
            SpawnEnemy();
            enemySpawnTimer = gameData.TimeBetweenEnemySpawn;
        }

        if (gameSessionTime >= gameData.SessionTimeSeconds)
        {
            GameVictory();
        }
    }

    private void OnCharacterDeath(Character character)
    {
        if (character == null) return;

        character.LiveComponent.OnCharacterDeath -= OnCharacterDeath;
        characterFactory.ReturnCharacter(character);

        if (character.CharacterType == CharacterType.Player)
        {
            GameOver();
        }
        else
        {
            scoreSystem.AddScore(character.CharacterData.ScoreCost);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = characterFactory.GetCharacter(CharacterType.DefaultEnemy);
        Vector3 playerPos = characterFactory.Player.transform.position;
        float offsetX = Random.Range(gameData.MinSpawnOffset, gameData.MaxSpawnOffset) * (Random.value > 0.5f ? 1 : -1);
        float offsetZ = Random.Range(gameData.MinSpawnOffset, gameData.MaxSpawnOffset) * (Random.value > 0.5f ? 1 : -1);
        enemy.transform.position = new Vector3(playerPos.x + offsetX, 0, playerPos.z + offsetZ);
        enemy.LiveComponent.OnCharacterDeath += OnCharacterDeath;
    }

    private void GameVictory()
    {
        EndGame();
        windowsService.HideWindow<GameplayWindow>(true);
        windowsService.ShowWindow<VictoryWindow>(false);
        Debug.Log("Victory");
    }

    private void GameOver()
    {
        EndGame();
        windowsService.HideWindow<GameplayWindow>(true);
        windowsService.ShowWindow<DefeatWindow>(false);
        Debug.Log("Defeat");
    }

    private void EndGame()
    {
        isGameActive = false;
        scoreSystem.EndGame();
    }
}
