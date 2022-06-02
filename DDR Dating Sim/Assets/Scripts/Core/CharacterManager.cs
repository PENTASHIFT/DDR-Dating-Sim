using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// responsible for adding character to scene
public class CharacterManager : MonoBehaviour
{
	//static
	public static CharacterManager instance;
    
	// characters on the panel
	public RectTransform characterPanel;
	// list of all characters
	public List<Character> characters = new List <Character>();
	
	public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();
	
	void Awake()
	{
		instance = this;
	}
	
	// get character by name from character list
	public Character GetCharacter(string characterName, bool createCharacterIfDoesNotExist = true, bool enableCreatedCharacterOnStart = true)
	{
		int index = -1;
		if (characterDictionary.TryGetValue (characterName, out index))
		{
			return characters[index];
		}
		else if (createCharacterIfDoesNotExist)
		{
			return CreateCharacter(characterName, enableCreatedCharacterOnStart);
		}
		return null;
	}
	
	public Character CreateCharacter(string characterName, bool enableOnStart = true)
	{
		Character newCharacter = new Character (characterName, enableOnStart);

		characterDictionary.Add (characterName, characters.Count);
		characters.Add (newCharacter);

		return newCharacter;
	}

	public class CHARACTERPOSITIONS
    {
		public Vector2 left = new Vector2 (0,0);
		public Vector2 off_left = new Vector2 (-1f,0);
		public Vector2 right= new Vector2 (1f,0);
		public Vector2 off_right = new Vector2(2f, 0);
		//public Vector2 center = new Vector2 (0.5f,0);
	}
}
