using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Die : MonoBehaviour {
	[SerializeField] Specifications Stat;
	[SerializeField] ParticleSystem Explosion;

	private void Start ( ) {
		Stat.EventDie += Stat_EventDie;
	}

	private void Stat_EventDie ( GameObject obj ) {
		ParticleSystem bomb = Instantiate ( Explosion ) as ParticleSystem;
		bomb.transform.position = this.transform.position;
		bomb.Play ( );
		bomb.enableEmission = true;
		//Debug.Log( "Die" );																																				

		if ( GameObject.Find ( "Controller" ).GetComponent<BotCollection> ( ).Bots.Count == 1 ) {
			//	Debug.Log( "New Generation" );
			GameObject.Find ( "Controller" ).GetComponent<BotStartSpawn> ( ).ThisSave.GenerationCount++;
			StartCoroutine ( GameObject.Find ( "Controller" ).GetComponent<BotStartSpawn> ( ).StartSpawn ( ) );
			SaveData ( );
		}

		GameObject.Find ( "Controller" ).GetComponent<BotCollection> ( ).Bots.Remove ( this.gameObject );
		GameObject.Find ( "Controller" ).GetComponent<BotCollection> ( ).WebTree.NewValue ( this.gameObject.GetComponent<Specifications> ( ).Web );

		Destroy ( bomb.gameObject, 2f );
		Destroy ( this.gameObject );
	}

	private void SaveData ( ) {
		StreamWriter objFile;

		if ( !File.Exists ( "Log.txt" ) )
			File.Create ( "Log.txt" );

		objFile = new StreamWriter ( "Log.txt", true );

		objFile.WriteLine ( Stat.Name + "_" + Stat.LifeTime.ToString ( ) + "_" + Stat.BotData.Move.ToString ( ) + "_" + Stat.BotData.Kill.ToString ( ) + "_" + Stat.BotData.Eat.ToString ( ) + "_" + Stat.BotData.Generation.ToString ( ) );

		objFile.Close ( );

		Debug.Log ( "SaveData" );
	}
}