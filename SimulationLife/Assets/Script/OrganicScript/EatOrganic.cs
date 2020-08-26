using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatOrganic : MonoBehaviour {
	[SerializeField] ParticleSystem Partical;

	public void MoveEat() {
		ParticleSystem bomb = Instantiate ( Partical ) as ParticleSystem;
		bomb.transform.position = this.transform.position;
		bomb.Play ( );
		bomb.enableEmission = true;
		Destroy ( this.gameObject );
	}
}
																													  