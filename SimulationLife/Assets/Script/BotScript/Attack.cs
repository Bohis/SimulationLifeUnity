using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	/// <summary>
	///	Object reference with characteristics
	/// </summary>
	[SerializeField] Specifications Stat;

	/// <summary>
	/// Attac bots
	/// </summary>
	public void AttacMove() {
		Collider [] BotColl = Physics.OverlapSphere( transform.position, Stat.RadiusAction );
		foreach (Collider thisObject in BotColl) {
			Vector3 direction = thisObject.transform.position - transform.position;
			if (Vector3.Dot( transform.forward, direction ) > 0.5f) {
				if (this.tag == "Bot") {
					try {
						Stat.Energy += thisObject.GetComponent<Specifications>().HP;
						thisObject.GetComponent<Specifications>().HP = 0;
						Stat.BotData.Kill++;
					}
					catch { }
					return;
				}
			}
		}
		/// Find web
		Stat.Web.ValueCrit--;
		Stat.HP -= 10;
	}
}