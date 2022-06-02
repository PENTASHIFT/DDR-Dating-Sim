using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // solely for contains functionality
using UnityEngine.SceneManagement;

public class final2_1 : MonoBehaviour
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
		"On every other day, the camp basically lets all of us form groups as a chance to not only get ready for Friday’s big performance day, but to also let us “network”. But I think the networking thing is getting to people’s heads. I even saw someone handing out business cards earlier?:(You)",
		"As for my networking day… umm, it could be better… I’m with this group where they really like my piano skills and basically they need someone to support whatever tune they feel is right. But it’s not going as well as I thought, at least for the others in the group.:(You)",
		"Alright,from the top again please! Some of you are off key or somethin’. Just try to keep up, yea?:Main Singer",
		"The others in the group look fed up with him at this point and then the guitarist starts to speak up.:Narrator",
		"Look, we’re trying our best here! The shift in your voice keeps screwing around with the tonality!:Guitarist",
		"The main singer looks back at him with a dirty look and rotates back to whisper something.:Narrator",
		"(Whispers) Maybe you need to watch your tonality…:Main Singer",
		"Yeah, it wasn’t much of a “whisper”, the poor guy is definitely fed up with us as indicated by the concerning vein on his head. The snarky glare from the singer also could have just pissed the guitarist off.:Narrator",
		"LISTEN DICKHEAD! I THINK YOU NEED A LESSON IN-:Guitarist",
		"Yeah, the guitarist is really not having it. Then one thing leads to another, the rest of the group intervenes with these two bickering and I honestly don’t want any part of it. So I just sit at my bench, hoping the music counselor would eventually come back soon.:Narrator",
		"Hey guys, how’s the practi-:Mandy:Happy",
		"Oh thank goodness he’s back! When he walked in to check on us, he’s just baffled at these kids that had to hold two people back from basically having a dispute over the singer being tonedeaf. I guess this wasn’t what they had in mind when they wanted us to “get along and network”. The music counselor then steps in between the group and separates them.:(You)",
		"WOAH WOAH WOAH!...:Mandy:Sad",
		"His sudden volume shocks us a bit. And we all just stand there, waiting for some kinda lecture about how physical violence is never okay.:Narrator",
		"...",
		"But then there's this really long awkward silence.:Narrator",
		"...",
		"That is somehow more effective in calming the rest of the group down. But then we realized how new this music counselor is as he pulls out a “rule book”?:Narrator",
		"(muttering) How to… dispel civil disagreements? What if a physical altercation happens? Oh my gosh, these kids are looking at me?:Mandy:Sad",
		"At this rate, all of us are baffled at him. And another round of awkwardness came until I looked at the clock and noticed it was getting around to noon.:Narrator",
		"Hey… I’m feeling kinda hungry guy–:You",
		"Oh really!? How bout that? It’s almost lunch time! Why don’t we just pause on this… great team bonding experience and get some grub! C’mon!:Mandy:Happy",
		"The music counselor goes to open the door and gestures to us the way out. The rest of the group look at each other and just shrug. One by one, we all start to walk out. Since I’m the last one out, the counselor tells me to lock the door.:Narrator",
		"But as I’m walking to the door, I hear a creak behind me. I turn to see that the studio door is moving a bit, like someone just entered. I look to see if others noticed me not there, but they didn’t care.:Narrator",
		"So I go to the door to see what’s up. I take a peek and see this girl scouting out the guitars. She seems a bit nervous yet excited. She then starts to pick a guitar, turn on the sound system,and starts tuning.:Narrator:EnterKarymeNeutral",
		"I was going to step in, but she then pauses. I thought she heard me, but she starts to play this beautiful solo! Watching her play is like watching someone that just… knows the soul of a guitar.:Narrator",
		"She’s so good! I just had to give her credit! Maybe if I could open the door just a tiny bit… And the door creaked… really loudly!!! By then, she stops playing at the sound of the door, and by the sight of me, standing there… like a buffoon.:Narrator",
		"Uhh, WOW! That solo was just… PHENOMENAL! I totally wasn’t here just to stare at you for a long time, that’ll be weird, right?:You",
		"Yeah, at one point, you just gotta break eye contact or someone will notice.:?:Blush",
			":You",
			"Ohh uhh, okay for one, you gotta walk in as if you were just there so you don’t seem like a creep.:?:Neutral",
			"Oh my gosh, I’M KIDDING! Hahaha!:?:Happy",
		"But I guess I wasn’t being too discreet when you guys walked outta here. I’m guessing you already heard me practicing?:?:Neutral",
		"Wait, that was just practi- that entire solo was just practice!?:You",
		"Oh it’s just some lil tune I had in mind.:Neutral:Hapy",
		"For a tune, it sounded so… good! It was played so beautifully. I don’t know why I’m making such a big deal out of this, but… I guess it’s a nice break from the… bombastic performances from yesterday.:You",
		"It sounded real bombastic right before I came in here.:Neutral",
		"Oh no, you heard the-:You",
		"The tonedeaf singer with the narcissism complex? Oh yeah, I definitely heard him.:?:Neutral",
		"Yeah, I guess I’m gonna have to deal with… not so pleasant people in certain groups.:You",
		"Groups?:?:Neutral",
		"Well, it turns out a lot of people on orientation day actually asked me to practice with them when I duoed with a singer. Some of the groups even offered me a role for their big performance this Friday! So for the next few days, I’m gonna go around and practice with others and see how it goes!:You",
		"Ooh, Mr. Popular much?:?:Happy",
		"No no no! Heh, it’s… nice to meet all these people and play with them.:You",
			":You",
			"Oh, good for you then! But I think the networking thing is really getting to people’s heads.:?:Happy",
			"Well… they probably liked you enough to realize that your talent is their next big shot to fame.:?:Neutral",
		"You… could be right on that, but I don’t think it’s that ba-:You",
		"You have no idea how many business cards I’ve seen on the floor as I was walking around camp.:?:Neutral",
		"Okay, that is a bit much. But other than that, it’s been pretty fun! I get to meet and play with all these people! I might even make a few friends here and there.:You",
		"You’re starting to sound like a sellout. At least you sound more convincing to go here, I’ll give you that.:?:Sad",
			":You",
			"Well… it’s not that I don’t like the place… It’s more like I hate how you have to enter it…:?:Sad",
			"There’s this… barrier of entry that just sucks…:?:Sad",
		"Entry… like the entry fees?:You",
		"BINGO! Like how they require at least 1k to sleep here!:?Neutral",
		"That is a bit much for a dorm… and on top of that, there’s the other 1k for the instrument insurance…:You",
		"Oh, real thoughtful of them right? I gotta worry about paying that much to NOT break their crap!:?:Happy",
		"That is a lot asking from high school kids… but at least we all get to play right?:You",
		"She then gives me this big sigh. And her expression changes to being so… discouraging.:Narrator:EnterKarymeSad",
		"If I’m gonna be honest… I’m not even supposed to be here.:?:Sad",
			":You",
			"Through deception! And all of my money, which was half of the entry fees by the way.:?:Sad",
			"Well, I did…  muster up 1k to at least step foot in here! Which was, all I had really…:?:Sad",
		"What happens if you don’t pay the rest?:You",
		"Then they actually won’t let me play. Bummer, right? So I had to spin up a lie where my parents are coming with the money as soon as they can… but the counselors don’t really care. So I’ve been sneaking around. (whispers) And I’m not even supposed to be in here either.:?:Neutral",
		"I never realized how expensive music can be. Even if people can afford to go here, music shouldn’t be exclusive just because people can’t afford it, right?:?:Neutral",
		"Oh, I’m… I’m sorry they told you that. That… really doesn’t seem fair!:You",
		"Aww, I appreciate your concern. But you don’t have to worry that much. At least they don’t spend their budget worrying about security.:?:Happy",
		"Securit-:You",
		"You have no idea how cheap their locks are. All it took was a hairpin and good luck. Too bad that kinda luck doesn’t cover expenses…:?:Neutral",
		"I couldn’t just sit there and play down her situation.:(You)",
		"No… don’t do that. You can’t blame yourself for something that’s out of your control. You wanted to go here, you clearly got what it takes, but you can’t afford it. If I were the guy in charge here, I’d say that kinda passion and talent… is good enough to let you in here.:You",
		"She then looks up at me surprised.:Narrator:EnterKarymeBlush",
		"AND just from what I heard, I can tell you play like no one else here. Not even the guitarist that I was playing with earlier.:You",
		"Now he played pretty well and had the right temper when it came to that prick.:?:Happy",
		"Heh, okay fine! But you’re not giving yourself enough credit here! You have a lot of potential... I also understand that money is a big issue for you. So, if you wanna continue playing… I’ll keep my mouth shut. I can see you’re passionate, and sometimes that counts for a lot more than what money can say.:You",
		"Right then and there, she turns to look at me with a more grateful expression. Then she sighs a huge relief.:?:Neutral",
		"Huh. Ya know, I can tell everyone was so caught up with “networking” and “looking their best.” And… I know they mean well and they want what’s best for them… but it just seems so… tacky! But I can see why people like you. You get it. You really care! I don’t know if you’re completely okay with me lying to stay here, but if you can tolerate my playing, I suppose I can risk it all.:?:Neutral",
		"Tolerate it!? I’d rather listen to it all day long.:You",
		"She chuckles at my response. Okay, I did sound so sappy for the last minute, but she gives a nice grin, like she felt secure for once.:?:Happy",
		"Okay well… since we established this weird bond of lies and deceit… how bout we actually take advantage of “music camp” and just practice for once?:?:Neutral",
		"Oh yeah for sure! What do you have in mind?:You",
		"Hmm, since apparently everyone loves you, how bout you surprise me? Try to play something else outside of your comfort zone.:?:Neutral",
		"Hmm, always wanna keep things interesting. I’d like that in someone.:(You)",
			":You",
			"Well, I don’t wanna force ya or nothin-:?:Sad",
			"I said something outside of your “comfort” zone, I’m not asking you to fight anything.:?:Neutral",
		"Hey hey, I’m… getting around to the outer… zone of the comfort… that made no sense.:You",
		"She then chortles at my stupid choice of words. And with every right to do so. But there’s just so much to play here!:Narrator:EnterKarymeHappy",
		"It’s just that… there’s a lotta options on what you want me to play.:You",
		"Okay, you got a point. What pairs well with a guitar?:?:Neutral",
			":You",
			"Ohh, that’s an… interesting combo! Yeah, let’s go with that!:?:Happy",
			"I see we’re about to go full on Bohemian Rhapsody here, I like it!:?:Happy",
			"Nothin’ beats a duo!:?:Happy",
			//gameplay
	};
	//include sound for piano, paper ruffling, bell sounds, more. need to import audio
	int[] choice = new int[]
	{
		30,45,52,62,86,93
	};

	int index = 0;
	// Update is called once per frame
	void Update()
	{
		//super hard coded choices. will fix this and make it a seperate class if we do this next year.
		//if (Input.GetKeyDown(KeyCode.E)) { ChoiceScreen.Show("karyme exit", "parker exit"); }

		if (index == 29) { ChoiceScreen.Show("Umm… yeah that’s a good point, any other tips?", "Ohh NO! I swear I was around here and I thought I heard somethi-"); }
		if (index == 30 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[30]); changeEmotion(); index = 32; }
		else if (index == 30 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[31]); changeEmotion(); index = 32; }

		if (index == 44) { ChoiceScreen.Show("It’s a… good feeling! To ya know, feel needed for once.", "But… I’m just not used to getting all of this attention on me."); }
		if (index == 45 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[45]); changeEmotion(); index = 47; }
		else if (index == 45 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[46]); changeEmotion(); index = 47; }
		
		if (index == 61) { ChoiceScreen.Show("Hold on… how are you even here then?", "Wait!? You didn’t even pay for-"); }
		if (index == 62 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[62]); changeEmotion(); index = 64; }
		else if (index == 62 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[63]); changeEmotion(); index = 64; }

		if (index == 85) { ChoiceScreen.Show("Hold on… how are you even here then?", "Wait!? You didn’t even pay for-"); }
		if (index == 86 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[86]); changeEmotion(); index = 88; }
		else if (index == 86 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[87]); changeEmotion(); index = 88; }

		if (index == 92) { ChoiceScreen.Show("Hmm… a saxophone?", "An old fashioned piano?", "You know what’s better than one guitar? Two of them?"); }
		if (index == 93 && ChoiceScreen.lastChoiceMade.index == 0) { Say(s[93]); changeEmotion(); index = 96; }
		else if (index == 93 && ChoiceScreen.lastChoiceMade.index == 1) { Say(s[94]); changeEmotion(); index = 96; }
		else if (index == 93 && ChoiceScreen.lastChoiceMade.index == 2) { Say(s[95]); changeEmotion(); index = 96; }

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
		if (speaker == "?") { speaker = "Karyme"; }
		if (speaker == "You" || speaker == "(You)" || speaker == "Main Singer") { speaker = "Narrator"; }
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
			if (emotion == "EnterMandyBlush") { MandyOut(false); MandyBlushIn(); currentEmotionMandy = "Mandy_Blush"; }
			if (emotion == "EnterKarymeSad") { KarymeOut(false); KarymeSadIn(); currentEmotionKaryme = "Karyme_Sad"; }
			if (emotion == "EnterKarymeBlush") { KarymeOut(false); KarymeBlushIn(); currentEmotionKaryme = "Karyme_Blush"; }
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
