using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {
	[SerializeField] Light Flash;
	// Use this for initialization
	void Start () {
		Flash.gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown( KeyCode.L )) {
			Flash.gameObject.SetActive( !Flash .gameObject.active);
		}
	}
}
