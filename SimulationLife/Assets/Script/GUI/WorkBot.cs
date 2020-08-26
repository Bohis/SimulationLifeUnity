using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBot : MonoBehaviour {		 

	public bool TriggerWork;
	private void Start() {
		TriggerWork = false;
		this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Start";
	}

	public void OnClick() {
		TriggerWork = !TriggerWork;
		if (TriggerWork) {
			this.gameObject.transform.GetChild( 0 ).GetComponent<Text>().text = "Stop";
		}
		else {
			this.gameObject.transform.GetChild( 0 ).GetComponent<Text>().text = "Pause";
		}
	}
}
