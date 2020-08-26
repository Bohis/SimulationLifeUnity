using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using NeiralNet;

public class Specifications : MonoBehaviour {

	public int LifeTime = 0;

	///<summary>Структура для статистики </summary>
	public struct Statistic {
		public int Move;
		public int Kill;
		public int Eat;
		public int Generation;
	}

	public Statistic BotData;

	public string Name = string.Empty;

	public float Speed = 10f;

	public float RotationAngle = 45;

	public NeiralNet.NeuralNetwork Web;

	private GameObject _sun;

	public float Energy {
		set {
			if (value > 100) {
				_energy = 100;
				return;
			}
			_energy = value;
		}
		get { return _energy; }
	}

	public float Photosensitivity = 50f;

	public float RadiusAction = 2f;

	public delegate void baseMod(GameObject obj);

	public event baseMod EventDie;

	public int TrainCoof = 2;

	public float LightLevel = 0;
	public float PossibilityMove = 0;
	public float AvailabilityFood = 0;
	public float BreedingOpportunity = 0;
	private float _energy =50;
	private float _hp = 100;

	public float HP {
		get { return _hp; }
		set {
			if (value < 0) {
				if (EventDie!=null)
					EventDie( this.gameObject );
				return;
			}
			if (value > 100)
				_hp = 100;
			else
				_hp = value;
		}
	}

	private void Start() {
		BotData = new Statistic ( );

	   _sun = GameObject.FindWithTag("Sun");
		Web = new NeuralNetwork( TrainCoof );
		StartCoroutine( HPUpdateEnrgy() );
		StartCoroutine(LookAround());
	}	

	private IEnumerator HPUpdateEnrgy() {
		if (GameObject.Find( "StartButton" ).GetComponent<WorkBot>().TriggerWork) {
			HP += (float)( -0.0045 * _energy * _energy + 1.152 * _energy );

			yield return new WaitForSeconds( 5f );
		}
		else {
			yield return new WaitForSeconds( 0.1f );
		}																																								 
		StartCoroutine( HPUpdateEnrgy() );
	}

	private IEnumerator LookAround() {
		if (GameObject.Find( "StartButton" ).GetComponent<WorkBot>().TriggerWork) {
			LightLevel = ( _sun.transform.position - gameObject.transform.position ).magnitude / _sun.transform.position.y;
			try {
				LightLevel = Mathf.Sqrt( (float)( -0.42 * ( LightLevel - 2.2 ) ) );
				if (LightLevel != LightLevel)
					throw new System.Exception();
			}
			catch {
				LightLevel = 0;
			}

			PossibilityMove = 1;
			Collider [] BotColl = Physics.OverlapSphere( transform.position, RadiusAction );
			foreach (Collider thisObject in BotColl) {
				Vector3 direction = thisObject.transform.position - transform.position;
				if (Vector3.Dot( transform.forward, direction ) > 0.5f) {
					if (thisObject.tag != "Space" || thisObject.tag == "Wall") {
						PossibilityMove = 0;
						break;
					}
				}
			}

			AvailabilityFood = 0;
			Collider [] EatColl = Physics.OverlapSphere( transform.position, RadiusAction );
			foreach (Collider thisObject in EatColl) {
				Vector3 direction = thisObject.transform.position - transform.position;
				if (Vector3.Dot( transform.forward, direction ) > 0.5f) {
					if (thisObject.tag == "Organic") {
						AvailabilityFood = 1;
						break;
					}
				}
			}

			if (_energy >= 70) {
				BreedingOpportunity = 1;
			}
			else {
				BreedingOpportunity = 0;
			}

			StartMove();

			_hp -= 5;

			if (GameObject.Find( "Controller" ).GetComponent<BotStartSpawn>().ThisSave.MaxLifeCount < LifeTime)
				GameObject.Find( "Controller" ).GetComponent<BotStartSpawn>().ThisSave.MaxLifeCount = LifeTime;

			yield return new WaitForSeconds( 0.1f );
		}
		else { 
			yield return new WaitForSeconds( 0.1f );
		}
		StartCoroutine( LookAround() );
	}

	private void StartMove() {
		float[] hashArray = new float[6];

		hashArray[0] = LightLevel;
		hashArray [1]= PossibilityMove;
		hashArray [2]= AvailabilityFood;
		hashArray [3]= BreedingOpportunity;
		hashArray [4]= _energy;
		hashArray [5]= _hp;

		float[,] outValue = Web.WorkNet( hashArray );
		
		float maxValue = -2;
		int maxIndex = 0;						   

		for (int i = 0 ; i < 6 ;++i) {  			   
			if (maxValue < outValue [ 0, i ]) {
				maxValue = outValue [ 0, i ];
				maxIndex = i;
			}							
		}
		
		switch (maxIndex){
			case 0: {
				this.gameObject.GetComponent<MoveForward>().Move();
				break;
			}
			case 1: {
				this.gameObject.GetComponent<RotationBody>().Rotation( maxValue );
				break;
			}
			case 2: {
				this.gameObject.GetComponent<Eat>().EatMove();
				break;
			}
			case 3: {
				this.gameObject.GetComponent<Fotosintez>().MoveFotosintez();
				break;
			}
			case 4: {
				this.gameObject.GetComponent<Reproduction>().MoveReproduction();
				break;
			}
			case 5: {
				this.gameObject.GetComponent<Attack>().AttacMove();
				break;
			}
		}
		Web.ValueCrit++;
		LifeTime++;
	}
}
