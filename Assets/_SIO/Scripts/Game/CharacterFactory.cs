using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private Character playerCharacterPrefab;
    [SerializeField] private Character enemyCharacterPrefab;

    private readonly Dictionary<CharacterType, Queue<Character>> disabledCharacters = new();
    private readonly List<Character> activeCharacters = new();

    public Character Player { get; private set; }
    public List<Character> ActiveCharacters => activeCharacters;

    public Character GetCharacter(CharacterType type)
    {
        if (!disabledCharacters.ContainsKey(type))
        {
            disabledCharacters[type] = new Queue<Character>();
        }

        Character character = disabledCharacters[type].Count > 0
            ? disabledCharacters[type].Dequeue()
            : InstantiateCharacter(type);

        character.gameObject.SetActive(true);
        character.Initialize();
        activeCharacters.Add(character);
        return character;
    }

    public void ReturnCharacter(Character character)
    {
        character.gameObject.SetActive(false);
        activeCharacters.Remove(character);
        disabledCharacters[character.CharacterType].Enqueue(character);
    }

    private Character InstantiateCharacter(CharacterType type)
    {
        Character character = type switch
        {
            CharacterType.Player => Instantiate(playerCharacterPrefab),
            CharacterType.DefaultEnemy => Instantiate(enemyCharacterPrefab),
            _ => throw new System.ArgumentOutOfRangeException(nameof(type), "Unknown character type!")
        };

        character.Initialize();
        if (type == CharacterType.Player) Player = character;
        return character;
    }
}
