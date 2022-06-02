using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // solely for contains functionality
using UnityEngine.SceneManagement;

public class final1_1 : MonoBehaviour
{

	public float volume, pitch;
	public AudioClip[] clips;
	public AudioClip[] music;

	public Character Karyme_Neutral;
	public Character Karyme_Blush;
	public Character Karyme_Happy;
	public Character Karyme_Sad;
	public Character Parker_Neutral;
	public Character Parker_Blush;
	public Character Parker_Happy;
	public Character Parker_Sad;
	public Character Mandy_Neutral;
	public Character Mandy_Blush;
	public Character Mandy_Happy;
	public Character Mandy_Sad;
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
		Mandy_Neutral = CharacterManager.instance.GetCharacter("Mandy_Neutral");
		Mandy_Blush = CharacterManager.instance.GetCharacter("Mandy_Blush");
		Mandy_Happy = CharacterManager.instance.GetCharacter("Mandy_Happy");
		Mandy_Sad = CharacterManager.instance.GetCharacter("Mandy_Sad");

		currentEmotionKaryme = "KarymeNeutral";
		KarymeOut(true);
		ParkerOut(true);
		MandyOut(true);

		//AudioManager.instance.PlaySong(music[0], 0.3f, 1f, 0.0f, true, true);
	}

	public string[] s = new string[]
	{
		"There’s a lot of people here, huh? That must mean I’m at the right event. Guess there’s the registration line.:Narrator",
		"Hi! Are you here for the music camp?:?:Happy",
		"Um, yeah! Here, I should have the application printed out somewhere in my bag…:You",
		"There’s no need for that! I just need to know your name so I can look for it here.:?:Neutral",
			"Got it! My name is… (player inserts here), and my pronouns are (player inserts here).:You",
		"Wonderful, I found you here! Here is a pamphlet, your room key, an envelope with food vouchers at the hotel… if there’s anything missing, just let me or anyone on staff know! I hope you have an amazing experience here!:?:Happy",
		"Great, thank you so much!:You:EnterMandyNeutral",
		"I’m not regretting it so far, so maybe this was worth it. We’ll see eventually. Good to see there are some available seats.:(You)",
		"Hey guys! I’m super glad to see you all here! Welcome to the annual MuZ music camp!:?:Happy",
		"I’m Mandisa, but you guys can just call me Mandy. My pronouns are mainly she/her, but I don’t mind if you guys use anything else.:Mandy:Neutral",
		"I’m sure you guys have done your reading on the camp, but just to refresh you guys, this is the MuZ music camp. We host this annually for musicians from all over to connect with one another and just jam out on the fifth and last day!:Mandy:Neutral",
		"For how the camp goes, basically, we’ll be having different instrumental and vocal days for you guys to individually hone your talents. On the other days, we’ll generally have jamming sessions so you guys can choose who to perform with!Mandy:Neutral",
		"Locations, times, food vouchers, and all that should have already been provided to you. Let me or any of my co-staffers know if you’re missing something, have a question, or just generally want to chat!:Mandy:Neutral",
		"It’ll almost be noon, so we have some meals for you guys to eat before you head off to your first sessions. We hope you guys have fun!:Mandy:Heppy",
		"Would you like a pesto pasta bowl or a club sandwich?:Staffer:ExitMandy",
			":You",
			"Man, this tastes good…:(You)",
			"Man, this tastes good…:(You)"
	};

	int[] choice = new int[]
	{
		16
	};

	int index = 0;
	// Update is called once per frame
	void Update()
	{
		//super hard coded choices. will fix this and make it a seperate class if we do this next year.
		//if (Input.GetKeyDown(KeyCode.E)) { ChoiceScreen.Show("karyme exit", "parker exit"); }

		if (index == 15) { ChoiceScreen.Show("Pesto pasta sounds good, thanks!", "A club sandwich sounds great right now, thank you."); }
		if (index == 16 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[16]); index = 18; }
		else if (index == 16 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[17]);  index = 18; }

		/*
		if (index == 13) { ChoiceScreen.Show("karyme exit", "parker exit"); }
		if (index == 14 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[14]); changeEmotion(); index = 16; }
		else if (index == 14 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[15]); changeEmotion(); index = 16; }
		*/


		//increment text index and put it to the text box
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
			{
				if (index == s.Length)
				{
					DialogueSystem.instance.Close();
					SceneManager.LoadScene(sceneName:"Day1_2"); ;
				}

				if (choice.Contains(index) != true)
				{
					
					Say(s[index]);
					changeEmotion();
					index++;
				}
			}
		}
		//can be used as a undo button
		
		if (Input.GetKeyDown(KeyCode.U))
		{
			index = 13;
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

		//animation purposes
		if (speaker == "?") { speaker = "Mandy"; }
		if (speaker == "You" || speaker == "(You)" || speaker == "Staffer") { speaker = "Narrator"; }
	}

	public string currentEmotionKaryme = "Karyme_Exit";
	public string oldK = "Exit";
	public string currentEmotionParker = "Parker_Exit";
	public string oldP = "Exit";
	public string currentEmotionMandy = "Mandy_Exit";
	public string oldM = "Exit";
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
		else if (speaker == "Mandy" && currentEmotionMandy != newEmotion && newEmotion != "")
		{
			currentEmotionMandy = newEmotion;
			if (currentEmotionMandy == "Mandy_Exit") { MandyOut(true); }
			if (currentEmotionMandy == "Mandy_Neutral") { MandyOut(false); MandyNeutralIn(); }
			if (currentEmotionMandy == "Mandy_Blush") { MandyOut(false); MandyBlushIn(); }
			if (currentEmotionMandy == "Mandy_Happy") { MandyOut(false); MandyHappyIn(); }
			if (currentEmotionMandy == "Mandy_Sad") { MandyOut(false); MandySadIn(); }
		}
		//narrator options for changing emotions freely without specifying it in text
		else if (speaker == "Narrator")
		{
			if (emotion == "Exit") { KarymeOut(true); ParkerOut(true); MandyOut(true); currentEmotionKaryme = "Karyme_Exit"; currentEmotionParker = "Parker_Exit"; currentEmotionMandy = "Mandy_Exit"; }
			if (emotion == "Enter") { KarymeNeutralIn(); ParkerNeutralIn(); MandyNeutralIn(); currentEmotionKaryme = "Karyme_Neutral"; currentEmotionParker = "Parker_Neutral"; currentEmotionMandy = "Mandy_Neutral"; }
			if (emotion == "ExitKaryme") { KarymeOut(true); currentEmotionKaryme = "Karyme_Exit"; }
			if (emotion == "ExitParker") { ParkerOut(true); currentEmotionParker = "Parker_Exit"; }
			if (emotion == "ExitMandy") { MandyOut(true); currentEmotionMandy = "Mandy_Exit"; }
			if (emotion == "EnterKarymeNeutral") { KarymeOut(false); KarymeNeutralIn(); currentEmotionKaryme = "Karyme_Neutral"; }
			if (emotion == "EnterParkerNeutral") { ParkerOut(false); ParkerNeutralIn(); currentEmotionParker = "Parker_Neutral"; }
			if (emotion == "EnterMandyNeutral") { MandyOut(false); MandyNeutralIn(); currentEmotionMandy = "Mandy_Neutral"; }
		}

		// so much spaghetti is being made, but the deadline is wednesday. there was already an instant
		// transition so no animation would be done, but essentiall this just checks if the sprite is off
		// or on screen. if the sprite is off screen or is scheduled to go off screen, it gets animated.
		if (speaker == "Karyme") { oldK = emotion; }
		if (speaker == "Parker") { oldP = emotion; }
		if (speaker == "Mandy") { oldM = emotion; }
	}

	//Dirty character movement, lotta hardcoding but it works
	float moveSpeed = 1f;
	Vector2 rightIn = new Vector2(1f - 0.1f, 0);
	Vector2 rightOut = new Vector2(2f, 0);
	Vector2 leftIn = new Vector2(0 + 0.1f, 0);
	Vector2 leftOut = new Vector2(-1f, 0);
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
	void KarymeNeutralIn() { Karyme_Neutral.MoveTo(rightIn, moveSpeed, smooth); }
	void KarymeBlushIn() { Karyme_Blush.MoveTo(rightIn, moveSpeed, smooth); }
	void KarymeHappyIn() { Karyme_Happy.MoveTo(rightIn, moveSpeed, smooth); }
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
			currentEmotionParker = "Parker_Exit";
			oldP = "Parker_Exit";
		}
	}
	void ParkerNeutralIn() { Parker_Neutral.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerBlushIn() { Parker_Blush.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerHappyIn() { Parker_Happy.MoveTo(leftIn, moveSpeed, smooth); }
	void ParkerSadIn() { Parker_Sad.MoveTo(leftIn, moveSpeed, smooth); }
	void MandyOut(bool exitingScene = true)
	{
		if (exitingScene)
		{
			smooth = true;
			moveSpeed = 1f;
		}
		else if (oldM != "Mandy_Exit")
		{
			smooth = false;
			moveSpeed = 999999999999999999999999999999f;
		}
		else
		{
			smooth = true;
			moveSpeed = 1f;
		}
		Mandy_Neutral.MoveTo(rightOut, moveSpeed, smooth);
		Mandy_Blush.MoveTo(rightOut, moveSpeed, smooth);
		Mandy_Happy.MoveTo(rightOut, moveSpeed, smooth);
		Mandy_Sad.MoveTo(rightOut, moveSpeed, smooth);
		if (exitingScene)
		{
			currentEmotionMandy = "Mandy_Exit";
			oldM = "Mandy_Exit";
		}
	}
	void MandyNeutralIn() { Mandy_Neutral.MoveTo(rightIn, moveSpeed, smooth); }
	void MandyBlushIn() { Mandy_Blush.MoveTo(rightIn, moveSpeed, smooth); }
	void MandyHappyIn() { Mandy_Happy.MoveTo(rightIn, moveSpeed, smooth); }
	void MandySadIn() { Mandy_Sad.MoveTo(rightIn, moveSpeed, smooth); }
}