using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBody : MonoBehaviour {
	/// <summary>
	///	object reference with characteristics
	/// </summary>
	[SerializeField] Specifications Stat;

	/// <summary>
	/// Rotation bot 
	/// </summary>
	public void Rotation(float value) {
		transform.Rotate( 0, value * Stat.RotationAngle, 0 );
		Stat.BotData.Move++;
	}
}