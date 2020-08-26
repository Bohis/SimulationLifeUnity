using System.Collections;
using System.Collections.Generic;
using UnityEngine;				  

public class BotStartSpawn : MonoBehaviour {
	[SerializeField] private GameObject BotPrefab;
	[SerializeField] private GameObject floorObject;

	public float _countBotStart = 40;
	private float _radius = 0.1f;
	public DateGame ThisSave;

	// Use this for initialization
	void Start () {
		StartCoroutine(StartSpawn());
		ThisSave = new DateGame();
	}	 

	public IEnumerator StartSpawn() {
		if (GameObject.Find( "StartButton" ).GetComponent<WorkBot>().TriggerWork) {
			string GenerationCode = char.ConvertFromUtf32( Random.Range( 65, 91 ) );
			for (int i = 0 ; i < _countBotStart ; ++i) {
				GameObject @object = Instantiate( BotPrefab ) as GameObject;
				@object.transform.position = new Vector3( Random.Range( -490, 490 ),10, Random.Range( -490, 490 ) );
				@object.transform.Rotate(0,Random.Range(0,360),0);
				@object.transform.parent = floorObject.transform;
				this.gameObject.GetComponent<BotCollection>().Bots.Add( @object );
				if (GameObject.Find( "Controller" ).GetComponent<BotCollection>().WebTree.RootValue != null) {
					if (this.gameObject.GetComponent<BotCollection>()._bestWeb != null && this.gameObject.GetComponent<BotCollection>()._worstWeb != null) {
						if (_countBotStart * 0.1 >= i) {
							@object.GetComponent<Specifications>().Web = new NeiralNet.NeuralNetwork( this.gameObject.GetComponent<BotCollection>() ._worstWeb,false);
						}
						if (_countBotStart * 0.3 >= i) {
							@object.GetComponent<Specifications>().Web = new NeiralNet.NeuralNetwork( this.gameObject.GetComponent<BotCollection>()._worstWeb, true );
						}
						if (_countBotStart * 0.5 >= i) {
							@object.GetComponent<Specifications>().Web = new NeiralNet.NeuralNetwork( this.gameObject.GetComponent<BotCollection>()._bestWeb, true );
						}
						if (_countBotStart * 0.8 >= i) {
							@object.GetComponent<Specifications>().Web = new NeiralNet.NeuralNetwork( this.gameObject.GetComponent<BotCollection>()._bestWeb, false );
						}	
					}
					@object.GetComponent<Specifications>().Web = new NeiralNet.NeuralNetwork( NeiralNet.NeuralNetwork.Mixing( gameObject.GetComponent<BotCollection>().WebTree.MaxLeftValue(), gameObject.GetComponent<BotCollection>().WebTree.MaxRightValue() ),false );
				}
				//добавить проверку на объекты вокруг							   
				@object.GetComponent<Specifications>().Name = GenerationCode + Random.Range( 1000, 10000 ).ToString() + char.ConvertFromUtf32( Random.Range( 65, 91 ) );					 
			}
			StopCoroutine(StartSpawn());																			
		}
		else {
			yield return new WaitForSeconds( .1f );
			StartCoroutine( StartSpawn() );
		}
	}
}
