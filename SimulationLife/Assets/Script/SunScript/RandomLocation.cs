using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = new Vector3( Random.Range( -451, 450 ), Random.Range( 449, 550 ), Random.Range( -451, 450 ) );	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
