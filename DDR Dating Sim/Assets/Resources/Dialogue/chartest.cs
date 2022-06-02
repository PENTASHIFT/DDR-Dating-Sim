using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartest : MonoBehaviour
{

	public Character Karyme;

	// Start is called before the first frame update
	void Start()
	{
		Karyme = CharacterManager.instance.GetCharacter("Karyme_Happy");
	}

	public string[] speech;
	int i = 0;

	public Vector2 moveTarget;
	public float moveSpeed;
	public bool smooth;

	public int expressionIndex = 0;
	
    // Update is called once per frame
    void Update()
    {
		
        if (Input.GetKeyDown(KeyCode.Space))
		{
			if (i < speech.Length)
			{
				Karyme.Say(speech[i]);
			}
			else
			{
				DialogueSystem.instance.Close();
			}
			i++;
		}

		if (Input.GetKey (KeyCode.M))
        {
			Karyme.MoveTo(moveTarget, moveSpeed, smooth);
        }

		if (Input.GetKey(KeyCode.S))
		{
			Karyme.StopMoving(true);
		}

		if (Input.GetKey(KeyCode.E))
		{
			Karyme.SetExpression(expressionIndex);
		}

	}
	
}
