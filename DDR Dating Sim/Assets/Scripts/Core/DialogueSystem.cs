using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public float volume, pitch;
	public AudioClip[] clips;

	public static DialogueSystem instance;
	public ELEMENTS elements;
	// Ensure this is the only DialogueSystem in the scene
	void Awake()
	{
		instance = this;
	}
	
    
    void Start()
    {
        
    }
	
	// Place text in speechPanel textbox
	// parameters: what is said, whether it is additive, and by who
    public void Say(string speech, string speaker = "", bool additive = false)
	{
		StopSpeaking();
		speechText.text = targetSpeech;
		speaking = StartCoroutine(Speaking(speech, speaker, additive));
	}
	
	public void StopSpeaking()
	{
		// if a prior line is not finished but the next line is prompted, stop the prior line
		if (isSpeaking)
		{
			StopCoroutine(speaking);
		}
		speaking = null;
	}
	
	// Check if dialoge has finished printing and return true/false
	public bool isSpeaking {get{return speaking != null;}}
	[HideInInspector] public bool isWaitingForUserInput = false;
	
	string targetSpeech = "";
	Coroutine speaking = null;
	// Someone saying something
	IEnumerator Speaking(string speech, string speaker = "", bool additive = false)
	{
		speechPanel.SetActive(true);
		targetSpeech = speech;
		if (!additive) // overrite previous text
		{
			speechText.text = ""; // what is said
		}
		else // continue from where prior text left off
		{
			targetSpeech = speechText.text + targetSpeech;
		}
		speakerText.text = DetermineSpeaker(speaker); // who is saying it
		isWaitingForUserInput = false;

		//AudioManager.instance.PlaySFX(clips[0]);
		while (speechText.text != targetSpeech)
		{
			speechText.text += targetSpeech[speechText.text.Length];
			yield return new WaitForEndOfFrame();
		}
		
		// dialogue finished printing
		isWaitingForUserInput = true;
		while (isWaitingForUserInput)
		{
			yield return new WaitForEndOfFrame();
		}
		StopSpeaking();
	}
	
	// last speaker used is speaking unless speaker is specified
	string DetermineSpeaker(string s)
	{
		string retVal = speakerText.text;
		// "Narrator" displays empty speaker while "" displays previous speaker
		if (s != speakerText.text && s != "")
		{
			retVal = (s.ToLower().Contains("narrator")) ? "" : s;
		}
		return retVal;
	}
	
	// stop char dialogue
	public void Close()
	{
		StopSpeaking();
		speechPanel.SetActive(false);
	}
	
	[System.Serializable]
	public class ELEMENTS
	{
		// Dialogue related elements of the UI
		public GameObject speechPanel;
		public Text speakerText;
		public Text speechText;
	}
	public GameObject speechPanel {get{return elements.speechPanel;}}
	public Text speakerText {get{return elements.speakerText;}}
	public Text speechText {get{return elements.speechText;}}
}
