using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // solely for contains functionality
using UnityEngine.SceneManagement;

public class final1_2 : MonoBehaviour
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
		"It seems like this is the right place, room 109. Some people have already started playing their instruments too… and others are talking. It sounds lively, at least.:(You)",
		"Hey guys! It’s me, Mandy. How are you all? I know that some of you guys have started playing and talking already, but I’d like to give a quick overview.:Mandy:Happy",
		"I know we’re all here to meet and play our hearts out with other people, but don’t forget that we’re also here to get better at our expertises.:Mandy:Neutral",
		"We have basically every single instrument that you guys excel at, so go wild and learn from one another too! Just keep our instruments safe. There are also music sheets if you guys need them, but we encourage original creations!:Mandy:Neutral",
		"I’ll be here to moderate and make sure that everything’s going well- if you guys have any questions, just let me know! Otherwise, go have fun, everyone!:Mandy:Neutral",
			"This is so awkward. I wish I could move the pianos somewhere- hopefully nobody notices. I’ll just wait until tomorrow to socialize if I have to.:(You):ExitMandy",
		"Those scales weren’t too sloppy, but I haven’t practiced my octaves in a while. I wonder if they have any available music sheets for me to practice with…:(You)",
		"The protagonist looks around the room to see whether or not there are any free music sheets, poking and prodding around. They don’t find any sheets that pique their interest.:Narrator",
			"Well, it doesn’t seem like there’s much to see here. It’s a bit of everything, but it’s not even a bit of what I want. Seems like I should just play randomly and see where it goes…:(You)",
		"Huh? Hold on–:(You):EnterParkerNeutral",
		"Is that Parker? I feel like I’ve seen that face before, but Parker has always been popular and talented. Could just be someone else entirely too.:(You)",
		"The protagonist continues with their random piano playing, though they eventually resort to practicing again–essentially at a creative block now.:Narrator:ExitParker",
		"Well, that’s some time gone to nothing. I doubt I could just make anything on the fly right now–especially when I can’t get their face out of my head.:(You)",
		"But it’s not like I’m entirely sure it’s Parker. Besides, it’s not as if we were even close back then too.:(You)",
		"Then again, it would be nice to know someone—anyone—here, though…:(you)",
		"Either way, I guess it’s time to get started on anything I can make. Four days isn’t really a lot of time–:(you)",
		"Um, e- excuse me? Sorry, I thought I recognized you from somewhere…:?:Neutral",
		"That voice! It is Parker! But what are they doing here?:(you)",
		"Oh yeah, hi! I thought you looked familiar too, to be honest. I wasn’t entirely sure though.:You",
			"You’re (protagonist’s name), right? We went to high school together all those years ago. How’ve you been?:Parker:Happy",
		"I’m surprised they even remember me… it’s not like we ever even talked back then. Maybe we’d exchange glances in a class or club, but we never said a word to each other.:(You):EnterParkerNeutral",
		"Yeah, that’s me! I’m doing well, but honestly, I’m shocked you remember me—after all, we didn’t hang out all that much before.:You",
		"Oh- uh, well, that’s true, but we had a lot of music classes together. I hope it isn’t too weird that I remember that—?:Parker:Sad",
			":You",
			"That aside though, how have you been?:You:ParkerEnterNeutral",
			"That aside though, how have you been?:You",
		"I’ve been doing quite well, I guess… Things have just been so drastically different since high school. How have things gone on your end?:Parker:Neutral",
		"I’ve been busy, I’ve just been working your normal 9-to-5, but I’ve been trying to hone my piano skills more. Maybe pick up some other instruments along the way, but I really want to be the best at the piano.:You",
		"I’ve been playing for years, so I wonder just how far I can push myself, you know? What have you been up to, exactly?:You",
		"Well, I can sort of relate with you, to be honest. I’ve been busy with my job, but I’ve been trying to compose music on the side. I’ve released some works online, but I’ve been a little quiet.:Parker:Neutral",
			":You",
			"No, I wish. I’ve missed some work, come late sometimes, or I just am not able to pump anything out. It can be difficult, but thanks.:Parker:Neutral",
			"It’s a modest following- it really isn’t much. I sometimes wish I had more, but that isn’t my main priority.:Parker:Neutral",
		"My songs aren’t all that special, but I’ve been trying my best. You can listen to one of them sometime if you’d like… just… just not here if that’s alright with you.:Parker:Sad",
		"My Yubie channel’s “hope miser.” If you see anyone we know outside of this music camp though, please don’t tell them. I’m not exactly sure that people who aren’t really into more unconventional music will receive it kindly…:Parker:Neutral",
		"Oh, no worries about that! I’ll listen later tonight when I’m back–I’m really excited to give your music a go! Do you have any recommendations?:You",
		"Well, there’s “symphony of the brave” and “UNKN0WN.” I think those have received the most attention, but you should feel free to listen to anything you want– but, of course, there’s no pressure at all too!:Parker:Neutral",
			":You",
			"That one was made when I had baroque and Holtz playing in the background all the time. I like to think that you can hear a full-blown adventure in it painted in an exuberant red.:Parker:Happy",
			"I… I made that one just randomly. It was a fit of passion that I had around 5AM after having pulled an all-nighter and watching a sad romance film. It sounds like pitch black, like pure, pure black, to me.:Parker:Blush",
		"Your inspirations sound really… organic— if that makes sense… Do you compose things regularly, or do you just make a new piece whenever you feel like it?:You:EnterParkerNeutral",
		"I try to stick to a schedule–I do think that keeping myself on track would be healthy for me and maybe a stable music career in the future–but that’s just impossible right now. My job really isn’t enough to make me dedicate my hours to fixing my sleep schedule.:Parker:Neutral",
		"It also sounds… stupid, really, but sometimes inspiration just strikes you at the worst times, you know? I’ve had some past ideas in the early, early morning that I never got to act upon or even note down, and I really regret that.:Parker:Neutral",
		"I’ve had some similar experiences, honestly. It gets really tough when you think about it, but I’m sure that you’ve made some good pieces!:You",
			"That- well, thanks… that means a lot. I guess you’ll be able to decide for yourself eventually though.:Parker:Blush",
		"Well, I’m sure that I’ll be impressed no matter what. Composing’s tough, and to be able to make anything bearable to listen to is already amazing.:You",
		"Do you have any previous experience? It sounds like you’re at least a little familiar–I know some musicians who just play notes and are somehow unaware about music theory and all, so I wouldn’t be surprised if you know at least some things.:Parker:Neutral	",
		"Oh, well, I actually have some interest in composing, so I’ve dabbled a little but not to the extent that you have. Sometimes I just experiment with the piano, honestly.:You",
		"Well, that’s always better than nothing! Do you only ever use your piano, or do you still sing? I know you used to sing a lot, and I honestly really liked your voice.:Parker:Neutral",
		"Ah, thanks– but I don’t sing much anymore. I honestly stopped singing after high school since I’ve been pretty dedicated to mastering the piano.:You",
		"That makes a lot of sense— I know the feeling. I think that all of us have run out of time at some point.:Parker:Neutral",
		"D- Don’t let that get you down though! I know that you’ll be just fine.:Parker:Sad",
			":You",
			"Thank you, (protagonist’s name). We’ll be fine.:Parker:Happy",
			"That’s true, but we can and should always hope— I learned that it’s not always good to mope.:Parker:Neutral",
		"I believe that everything will become what it’s meant to be.:Parker:Neutral",
		"I hope that was a really productive session, you guys! The music room will still be open if you guys want to practice anytime during the week. Just don’t forget about opening and closing times!:Mandy:Neutral",
		"That was really quick— I’m glad we got to see each other again though.:You:ExitMandy",
		"Me too. It was nice to see you again! I’ll see you some other time, but hopefully we’re in the same group again sometime.:Parker:Happy",
		"It’s getting darker— I should probably go eat.:(You):ExitParker",
		"I can listen to Parker’s stuff on the way though.:(You)",
		"“hope miser” on Yubie. I think I’ve seen that name before…:(You)",
		"Nevermind, I guess. There’s nothing on Parker’s channel. Thing’s just blank all throughout.:(You)",
		"“hope miser” shows up on different music social sites, but I guess they’re all empty too. Maybe something happened— I don’t think it’d be anything about a copyright or inappropriate strike, but who knows?:(You)",
		"I can just ask Parker next time. I’m getting really hungry right now— not best to think on an empty stomach.:(You)"
	};
	//include sound for piano, paper ruffling, bell sounds, more. need to import audio
	int[] choice = new int[]
	{
		24,31,38,53
	};

	int index = 0;
	// Update is called once per frame
	void Update()
	{
		//super hard coded choices. will fix this and make it a seperate class if we do this next year.
		//if (Input.GetKeyDown(KeyCode.E)) { ChoiceScreen.Show("karyme exit", "parker exit"); }

		if (index == 23) { ChoiceScreen.Show("No, I guess not! I’m genuinely just surprised that you remember me though.", "A little, honestly. It’s been too long since then."); }
		if (index == 24 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[24]); changeEmotion(); index = 26; }
		else if (index == 24 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[25]); changeEmotion(); index = 26; }

		if(index == 30) { ChoiceScreen.Show("Oh, wow, that’s really cool! You must have good time management…", "A little, honestly. It’s been too long since then.Sounds like you must be quite popular."); }
		if (index == 31 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[31]); changeEmotion(); index = 33; }
		else if (index == 31 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[32]); changeEmotion(); index = 33; }

		if (index == 37) { ChoiceScreen.Show("“symphony of the brave” sounds quite intimidating…", "“UNKN0WN?” Sounds pretty mysterious."); }
		if (index == 38 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[38]); changeEmotion(); index = 40; }
		else if (index == 38 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[39]); changeEmotion(); index = 40; }

		if (index == 52) { ChoiceScreen.Show("Thanks, I believe in both of us! We’ll be fine.", "Thanks, but we can’t always tell, you know?"); }
		if (index == 53 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[53]); changeEmotion(); index = 55; }
		else if (index == 53 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[54]); changeEmotion(); index = 55; }

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

		//animation purposes
		if (speaker == "?") { speaker = "Parker"; }
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
		Parker_Neutral.MoveTo(rightOut, moveSpeed, smooth);
		Parker_Blush.MoveTo(rightOut, moveSpeed, smooth);
		Parker_Happy.MoveTo(rightOut, moveSpeed, smooth);
		Parker_Sad.MoveTo(rightOut, moveSpeed, smooth);
		if (exitingScene)
		{
			currentEmotionParker = "Parker_Exit";
			oldP = "Parker_Exit";
		}
	}
	void ParkerNeutralIn() { Parker_Neutral.MoveTo(rightIn, moveSpeed, smooth); }
	void ParkerBlushIn() { Parker_Blush.MoveTo(rightIn, moveSpeed, smooth); }
	void ParkerHappyIn() { Parker_Happy.MoveTo(rightIn, moveSpeed, smooth); }
	void ParkerSadIn() { Parker_Sad.MoveTo(rightIn, moveSpeed, smooth); }
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
		Mandy_Neutral.MoveTo(leftOut, moveSpeed, smooth);
		Mandy_Blush.MoveTo(leftOut, moveSpeed, smooth);
		Mandy_Happy.MoveTo(leftOut, moveSpeed, smooth);
		Mandy_Sad.MoveTo(leftOut, moveSpeed, smooth);
		if (exitingScene)
		{
			currentEmotionMandy = "Mandy_Exit";
			oldM = "Mandy_Exit";
		}
	}
	void MandyNeutralIn() { Mandy_Neutral.MoveTo(leftIn, moveSpeed, smooth); }
	void MandyBlushIn() { Mandy_Blush.MoveTo(leftIn, moveSpeed, smooth); }
	void MandyHappyIn() { Mandy_Happy.MoveTo(leftIn, moveSpeed, smooth); }
	void MandySadIn() { Mandy_Sad.MoveTo(leftIn, moveSpeed, smooth); }
}