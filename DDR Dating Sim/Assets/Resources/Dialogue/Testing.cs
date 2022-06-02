using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

	DialogueSystem dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }
	
	public string[] s = new string[]
	{
		"On every other day, the camp basically lets all of us form groups as a chance to not only get ready for Friday’s big performance day, but to also let us “network”. But I think the networking thing is getting to people’s heads. I even saw someone handing out business cards?:Narrator",
		"As for my networking day… umm, it could be better… I’ve gotten with this group where they really liked my piano skills and basically they needed someone to support whatever tune they felt was right. But it’s not going as well as I thought, at least for the others in the group.",
		
		"Alright,from the top again please! Some of you are off key or somethin’. Just try to keep up, yea?:Main Singer",
		"The others in the group look fed up with him at this point and then the guitarist starts to speak up.:Narrator",

		"Look, we’re trying our best here! The shift in your voice keeps screwing around with the tonality!:Guitarist",
		"The main singer looks back at him with a dirty look and rotates back to whisper something.:Narrator",

		"(Whispers) Maybe you need to watch your tonality…:Main Singer",
		"Yeah, it wasn’t much of a “whisper”, but we all knew he wasn’t having it with us. Or maybe it was just the guitarist.:Narrator"


	};
	
	int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
			{
				if (index >= s.Length)
				{
					return;
				}

				Say(s[index]);
				index++;
			}
			
		}
    }
	
	void Say(string s)
	{
		string[] parts = s.Split(':');
		string speech = parts[0];
		string speaker = (parts.Length >= 2) ? parts[1] : "";
		

		// second parameter determines if the text is additive and will continue from the last
		dialogue.Say(speech, speaker, false);
	}
	
}
