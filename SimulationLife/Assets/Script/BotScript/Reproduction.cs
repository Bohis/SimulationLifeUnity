using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NeiralNet;

public class Reproduction : MonoBehaviour {
	/// <summary>
	///	Object reference with characteristics
	/// </summary>
	[SerializeField] Specifications Stat;
	/// <summary>
	/// Template bot
	/// </summary>
	[SerializeField] GameObject BotPrafab; 
	/// Specification reproduct
	private float _priceRep = 70f;
	private float _randZoneMin = -3;
	private float _randZoneMax = 3;

	public void MoveReproduction() {
		
		if (Stat.Energy > _priceRep) {
			Stat.Energy -= _priceRep;
			//Debug.Log( "Reproduction => 1" );
			GameObject newBot = Instantiate( BotPrafab ) as GameObject;
			newBot.transform.position = this.gameObject.transform.position;
			newBot.transform.position = new Vector3( newBot.transform.position.x, newBot.transform.position.y, newBot.transform.position.z );
			newBot.transform.parent = GameObject.Find( "Floor" ).transform;
			newBot.transform.localScale = this.gameObject.transform.localScale;
			newBot.GetComponent<Specifications>().Name = char.ConvertFromUtf32( Random.Range( 65, 91 ) ) + Random.Range( 1000, 10000 ).ToString() + char.ConvertFromUtf32( Random.Range( 65, 91 ) );
			Mutation( newBot.GetComponent<Specifications>() );
			GameObject.Find( "Controller" ).GetComponent<BotCollection>().Bots.Add( newBot );
			Stat.BotData.Generation++;
		}
		else
		{
			Stat.Web.ValueCrit--;
			Stat.HP -= 10;
		}
	}
	/// <summary>
	/// Parameter mutation
	/// </summary>
	private void Mutation(Specifications baseStat) {
		baseStat.Photosensitivity = Stat.Photosensitivity + Random.Range( _randZoneMin, _randZoneMax );
		baseStat.Speed = Stat.Speed + Random.Range( _randZoneMin, _randZoneMax ); 
		baseStat.RotationAngle = Stat.RotationAngle + Random.Range( _randZoneMin, _randZoneMax );
		baseStat.Energy = 50;
		baseStat.HP = 100;
		baseStat.Web = new NeiralNet.NeuralNetwork( Stat.Web, true ); 
	}												 
}			 