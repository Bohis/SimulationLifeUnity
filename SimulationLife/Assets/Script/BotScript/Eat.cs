using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour {
	/// <summary>
	///	Object reference with characteristics
	/// </summary>
	[SerializeField] Specifications Stat;

	/// <summary>
	/// Eat organic
	/// </summary>
	public void EatMove() {
		/// Find object around
		Collider [] EatColl = Physics.OverlapSphere( transform.position, Stat.RadiusAction );
		foreach (Collider thisObject in EatColl) {
			Vector3 direction = thisObject.transform.position - transform.position;
			///  True distance
			if (Vector3.Dot( transform.forward, direction ) > 0.5f) {
				if (this.tag == "Organic") {
					Stat.Energy += thisObject.GetComponent<SpecificationsOrganic>().val;
					thisObject.GetComponent<EatOrganic>().MoveEat();
					Stat.BotData.Eat++;
					return;
				}
			}
		}
		/// Find web
		Stat.Web.ValueCrit--;
		Stat.HP -= 10;
	}
}