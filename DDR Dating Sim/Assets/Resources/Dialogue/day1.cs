using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // solely for contains functionality

public class day1 : MonoBehaviour
{
	public Character Karyme_Neutral;
	public Character Karyme_Blush;
	public Character Karyme_Happy;
	public Character Karyme_Sad;
	public Character Parker_Neutral;
	public Character Parker_Blush;
	public Character Parker_Happy;
	public Character Parker_Sad;
	DialogueSystem dialogue;

	// Start is called before the first frame update
	void Start()
	{
		dialogue = DialogueSystem.instance;
		//create all character instances off screen
		Karyme_Neutral = CharacterManager.instance.GetCharacter("Karyme_Neutral");
		Karyme_Blush = CharacterManager.instance.GetCharacter("Karyme_Blush");
		Karyme_Happy = CharacterManager.instance.GetCharacter("Karyme_Happy");
		Karyme_Sad = CharacterManager.instance.GetCharacter("Karyme_Sad");
		Parker_Neutral = CharacterManager.instance.GetCharacter("Parker_Neutral");
		Parker_Blush = CharacterManager.instance.GetCharacter("Parker_Blush");
		Parker_Happy = CharacterManager.instance.GetCharacter("Parker_Happy");
		Parker_Sad = CharacterManager.instance.GetCharacter("Parker_Sad");

		KarymeOut(true);
		ParkerOut(true);
	}

	public string[] s = new string[]
	{
		"KarymeHappy:Karyme:Happy",
		"KarymeSad:Karyme:Sad",
		"ParkerHappy:Parker:Happy",
		"ParkerHappy2:Parker:Happy",
		"ParkerUnchagned:Parker",
		"general character text which doesnt change emotions:Narrator",
		"ParkerSad:Parker:Sad",
		"ParkerExit:Parker:Exit",
		"ParkerNOCHANGE:Parker",
		"KarymeNOCHAANGES:Karyme",
		"NarratorParkerIN:Narrator:EnterParkerNeutral",
		"NarratorExitAll:Narrator:Exit",
		"NarratorEnter:Narrator:Enter",
		":protagonist",
		"Karyme:Karyme:Exit",
		"Parker:Parker:Exit",
		"ChoiceFinished:Narrator",
		":protagonist",
		"ExitAll:Narrator:Exit",
		"EnterAll:Narrator:Enter",
		"Choice2Finished:Narrator",
		"EndOfSample"
	};

	int[] choice = new int[]
	{
		14,18
	};

	int index = 0;
	// Update is called once per frame
	void Update()
	{
		//super hard coded choices. will fix this and make it a seperate class if we do this next year.
		//if (Input.GetKeyDown(KeyCode.E)) { ChoiceScreen.Show("karyme exit", "parker exit"); }

		if (index == 17) { ChoiceScreen.Show("exit", "enter"); }
		if (index == 18 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[18]); changeEmotion(); index = 20; }
		else if (index == 18 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[19]); changeEmotion(); index = 20; }

		if (index == 13) { ChoiceScreen.Show("karyme exit", "parker exit"); }
		if (index == 14 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[14]); changeEmotion(); index = 16; }
		else if (index == 14 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[15]); changeEmotion(); index = 16; }

		

		//increment text index and put it to the text box
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
			{
				if (index >= s.Length)
				{
					return;
				}

				if (choice.Contains(index) != true)
				{
					Say(s[index]);
					changeEmotion();
					index++;
				}
			}
		}
	}


	//should be a different class whiich has variables for emotion and character name. this should work with multi image characters.
	void Say(string s)
	{
		string[] parts = s.Split(':');
		string speech = parts[0];
		speaker = (parts.Length >= 2) ? parts[1] : "";
		emotion = (parts.Length >= 3) ? parts[2] : "";

		// second parameter determines if the text is additive and will continue from the last
		dialogue.Say(speech, speaker, false);
	}

	public string currentEmotionKaryme = "Karyme_Exit";
	public string oldK = "Exit";
	public string currentEmotionParker = "Parker_Exit";
	public string oldP = "Exit";
	string speaker;
	string emotion;
	bool smooth = true;
	void changeEmotion() 
    {
		smooth = true;
		moveSpeed = 1f;
		string newEmotion = speaker + "_" + emotion;
		if (speaker == "Karyme" && currentEmotionKaryme != newEmotion && newEmotion != "")
        {
			currentEmotionKaryme = newEmotion;
			if (currentEmotionKaryme == "Karyme_Exit") { KarymeOut(true); }
			if (currentEmotionKaryme == "Karyme_Neutral") { KarymeOut(false); KarymeNeutralIn(); }
			if (currentEmotionKaryme == "Karyme_Blush") { KarymeOut(false); KarymeBlushIn(); }
			if (currentEmotionKaryme == "Karyme_Happy") { KarymeOut(false); KarymeHappyIn(); }
			if (currentEmotionKaryme == "Karyme_Sad") { KarymeOut(false); KarymeSadIn(); }
		}
		else if (speaker == "Parker" && currentEmotionParker != newEmotion && newEmotion != "")
		{
			currentEmotionParker = newEmotion;
			if (currentEmotionParker == "Parker_Exit") { ParkerOut(true); }
			if (currentEmotionParker == "Parker_Neutral") { ParkerOut(false); ParkerNeutralIn(); }
			if (currentEmotionParker == "Parker_Blush") { ParkerOut(false); ParkerBlushIn(); }
			if (currentEmotionParker == "Parker_Happy") { ParkerOut(false); ParkerHappyIn(); }
			if (currentEmotionParker == "Parker_Sad") { ParkerOut(false); ParkerSadIn(); }
		}
		//narrator options for changing emotions freely without specifying it in text
		else if (speaker == "Narrator")
        {
			if (emotion == "Exit") { KarymeOut(true); ParkerOut(true); currentEmotionKaryme = "Karyme_Exit"; currentEmotionParker = "Parker_Exit"; }
			if (emotion == "Enter") { KarymeNeutralIn(); ParkerNeutralIn(); currentEmotionKaryme = "Karyme_Neutral"; currentEmotionParker = "Parker_Neutral"; }
			if (emotion == "ExitKaryme") { KarymeOut(true); currentEmotionKaryme = "Karyme_Exit"; }
			if (emotion == "ExitParker") { ParkerOut(true); currentEmotionParker = "Parker_Exit"; }
			if (emotion == "EnterKarymeNeutral") { KarymeNeutralIn(); currentEmotionKaryme = "Karyme_Neutral"; }
			if (emotion == "EnterParkerNeutral") { ParkerNeutralIn(); currentEmotionParker = "Parker_Neutral"; }
		}

		// so much spaghetti is being made, but the deadline is wednesday. there was already an instant
		// transition so no animation would be done, but essentiall this just checks if the sprite is off
		// or on screen. if the sprite is off screen or is scheduled to go off screen, it gets animated.
		if (speaker == "Karyme") { oldK = emotion; }
		if (speaker == "Parker") { oldP = emotion; }
	}

	//Dirty character movement, lotta hardcoding but it works
	float moveSpeed = 1f;
	Vector2 rightIn = new Vector2 (1f, 0);
	Vector2 rightOut = new Vector2 (2f, 0);
	Vector2 leftIn = new Vector2 (0, 0);
	Vector2 leftOut = new Vector2 (-1f, 0);
	void KarymeOut(bool exitingScene = false)
    {
		// change this to be instant transition in final product
		if (exitingScene)
        {
			smooth = true;
			moveSpeed = 1f;
        }
		else if (oldK != "Karyme_Exit")
        {
			smooth = false;
			moveSpeed = 999999999999999999999999999999f;
        }
		else
        {
			smooth = true;
			moveSpeed = 1f;
		}
		Karyme_Neutral.MoveTo(rightOut, moveSpeed, smooth);
		Karyme_Blush.MoveTo(rightOut, moveSpeed, smooth);
		Karyme_Happy.MoveTo(rightOut, moveSpeed, smooth);
		Karyme_Sad.MoveTo(rightOut, moveSpeed, smooth);
		if (exitingScene)
		{
			currentEmotionKaryme = "Karyme_Exit";
			oldK = "Karyme_Exit";
		}
	}
	void KarymeNeutralIn() {  Karyme_Neutral.MoveTo(rightIn, moveSpeed, smooth); }
	void KarymeBlushIn() { Karyme_Blush.MoveTo(rightIn, moveSpeed, smooth); }
	void KarymeHappyIn() {  Karyme_Happy.MoveTo(rightIn, moveSpeed, smooth); }
	void KarymeSadIn() { Karyme_Sad.MoveTo(rightIn, moveSpeed, smooth); }
	void ParkerOut(bool exitingScene = true)
    {
		if (exitingScene)
		{
			smooth = true;
			moveSpeed = 1f;
		}
		else if (oldP != "Parker_Exit")
		{
			smooth = false;
			moveSpeed = 999999999999999999999999999999f;
		}
		else
		{
			smooth = true;
			moveSpeed = 1f;
		}
		Parker_Neutral.MoveTo(leftOut, moveSpeed, smooth);
		Parker_Blush.MoveTo(leftOut, moveSpeed, smooth);
		Parker_Happy.MoveTo(leftOut, moveSpeed, smooth);
		Parker_Sad.MoveTo(leftOut, moveSpeed, smooth);
		if (exitingScene)
		{
			currentEmotionParker = "Karyme_Exit";
			oldP = "Parker_Exit";
		}
	}
	void ParkerNeutralIn() { Parker_Neutral.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerBlushIn() { Parker_Blush.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerHappyIn() { Parker_Happy.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerSadIn() { Parker_Sad.MoveTo(leftIn, moveSpeed, smooth); }
}