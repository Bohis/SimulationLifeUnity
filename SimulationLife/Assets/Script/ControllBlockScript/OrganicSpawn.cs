using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicSpawn : MonoBehaviour {
	[SerializeField] private GameObject organicPrefab;
	[SerializeField] private GameObject floorObject;
	public  List<GameObject> _arrayOrganic;

	private int _countOrganic = 10;
	private float _radius = 0.1f;

	// Use this for initialization
	void Start () {
		_arrayOrganic = new List<GameObject>();
		StartCoroutine( NewOrganic() );
	}
	
	// Update is called once per frame
	void Update () {
	}

	private IEnumerator NewOrganic() {
		if (GameObject.Find( "StartButton" ).GetComponent<WorkBot>().TriggerWork) {
			if (_arrayOrganic.Count < 20) {
				for (int i = 0 ; i < _countOrganic / 5 ; ++i) {
					GameObject @object = Instantiate( organicPrefab ) as GameObject;
					@object.transform.position = new Vector3( Random.Range( -490, 490 ), 10, Random.Range( -490, 490 ) );
					@object.transform.parent = floorObject.transform;
					_arrayOrganic.Add( @object );
					//добавить проверку на объекты вокруг
				}
			}
			yield return new WaitForSeconds( 3f );
		}
		else {
			yield return new WaitForSeconds( .1f );
		}
		StartCoroutine( NewOrganic() );
	}
}
