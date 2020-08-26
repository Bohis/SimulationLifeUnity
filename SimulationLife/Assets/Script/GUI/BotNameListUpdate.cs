using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotNameListUpdate : MonoBehaviour {
	string text = string.Empty;
	// Use this for initialization
	void Start() {
	
	}

	// Update is called once per frame
	void FixedUpdate() {
		text = string.Empty;
		//GameObject.Find( "ScrollbarLeft" ).GetComponent<Scrollbar>().value = 1;

		foreach (GameObject s in GameObject.Find( "Controller" ).GetComponent<BotCollection>().Bots) {
			text += s.GetComponent<Specifications>().Name + "\n";
		}
		GameObject.Find( "TextName" ).GetComponent<Text>().text = text;

		GameObject.Find( "CountBoxBot" ).GetComponent<Text>().text = GameObject.Find( "Controller" ).GetComponent<BotCollection>().Bots.Count.ToString();
		
		GameObject.Find( "CountBoxGeneration" ).GetComponent<Text>().text = GameObject.Find( "Controller" ).GetComponent<BotStartSpawn>().ThisSave.GenerationCount.ToString();
		
		GameObject.Find( "CountBoxLife" ).GetComponent<Text>().text = GameObject.Find( "Controller" ).GetComponent<BotStartSpawn>().ThisSave.MaxLifeCount.ToString();
	}
}