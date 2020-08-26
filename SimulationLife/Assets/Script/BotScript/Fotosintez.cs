using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fotosintez : MonoBehaviour {
	/// <summary>
	///	Object reference with characteristics
	/// </summary>
	[SerializeField] Specifications Stat;

	/// <summary>
	/// Food photosynthesis
	/// </summary>
	public void MoveFotosintez() {
		Stat.Energy += Stat.LightLevel * Stat.Photosensitivity;
		Stat.BotData.Eat++;
	}
}					