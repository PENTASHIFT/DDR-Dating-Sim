using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
	// displayed when speaking
	public string characterName;
	
	// root of the character
	[HideInInspector]public RectTransform root;
	// multi/single layer
	bool isMultiLayerCharacter{get{return renderers.renderer == null;}}
	
	public bool enabled {get{return root.gameObject.activeInHierarchy;} set{ root.gameObject.SetActive (value);}}

	public Vector2 anchorPadding { get { return root.anchorMax - root.anchorMin; } }
	
	DialogueSystem dialogue;
	
	public void Say(string speech, bool additive = false)
	{
		if (!enabled)
		{
			enabled = true;
		}
		dialogue.Say(speech, characterName, additive);
	}

	Vector2 targetPosition;
	Coroutine moving;
	bool isMoving { get { return moving != null; } }
	public void MoveTo(Vector2 Target, float speed, bool smooth = true)
    {
		StopMoving();
		moving = CharacterManager.instance.StartCoroutine(Moving(Target, speed, smooth));
    }

	public void StopMoving(bool arriveAtTargetPositionImmediately = false)
    {
		if (isMoving)
		{
			CharacterManager.instance.StopCoroutine(moving);
			if (arriveAtTargetPositionImmediately)
            {
				setPosition(targetPosition);
            }
		}
		moving = null;
    }

	public void setPosition(Vector2 target)
    {
		Vector2 padding = anchorPadding;
		float maxX = 1f - padding.x;
		float maxY = 1f - padding.y;
		Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);
		root.anchorMin = minAnchorTarget;
		root.anchorMax = root.anchorMin + padding;
	}

	IEnumerator Moving(Vector2 target, float speed, bool smooth)
    {
		targetPosition = target;

		Vector2 padding = anchorPadding;
		float maxX = 1f - padding.x;
		float maxY = 1f - padding.y;

		Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);
		speed *= Time.deltaTime;

		while (root.anchorMin != minAnchorTarget)
		{
			root.anchorMin = (!smooth) ? Vector2.MoveTowards(root.anchorMin, minAnchorTarget, speed) : Vector2.Lerp(root.anchorMin, minAnchorTarget, speed);
			root.anchorMax = root.anchorMin + padding;
			yield return new WaitForEndOfFrame();
		}
		StopMoving();
    }

	//Begin
	public RawImage GetExpression(int index = 0)
	{
		//RawImage expression = Resources.Load<RawImage>("images/sprites/Karyme/Karyme_4");
		RawImage expression = Resources.Load<RawImage>("images/sprites/" + characterName + "/" + characterName + "_" + index);
		//Debug.Log(expression);
		//Debug.Log("images/sprites/" + characterName + "/" + characterName + "_" + index);
		return expression; //null
	}

	public void SetExpression(int index)
	{
		//Debug.Log(index);
		RawImage ri = GetExpression(index);
		renderers.renderer.texture = ri.texture;
		//renderers.renderer = Resources.Load<RawImage>("images/sprites/Karyme/Karyme_4");
	}

	/*
	public void SetExpression(RawImage expression)
	{
		//Debug.Log(image);
		renderers.renderer = expression;
	}
	*/
	//Img end

	// create new character
	public Character (string _name, bool enableOnStart = true)
	{
		CharacterManager cm = CharacterManager.instance;
		GameObject prefab = Resources.Load("Characters/Character["+ _name + "]") as GameObject;
		GameObject ob = GameObject.Instantiate (prefab, cm.characterPanel);
		
		root = ob.GetComponent<RectTransform> ();
		characterName = _name;
		
		renderers.renderer = ob.GetComponentInChildren<RawImage> ();

		/*
		// for use with multi-layer characters. disabled because it causes a problem with error message
		// "NullReferenceException: Object reference not set to an instance of an object"
		// please use only single layer characters for now until this is fixed
		if (isMultiLayerCharacter)
		{
			renderers.bodyRenderer = ob.transform.Find("bodyLayer").GetComponent<Image>();
			renderers.expressionRenderer = ob.transform.Find("expressionLayer").GetComponent<Image>();
		}
		*/

		dialogue = DialogueSystem.instance;
		enabled = enableOnStart;
	}
	
	[System.Serializable]
	public class Renderers
	{
		// single layer
		public RawImage renderer;
		// multi-layer
		public Image bodyRenderer;
		public Image expressionRenderer;
	}
	
	public Renderers renderers = new Renderers();
}
