using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	private float _speed = 50f;
	private float _minValue = 100f;

	[SerializeField] private GameObject StatusCursor;
	private LockCursor _statusCursor;
	struct AxesProperites {
		public float xMax;
		public float xSign;

		public float yMax;
		public float ySign;

		public float zMax;
		public float zSign;
	}

	AxesProperites _datePosition;
	// Use this for initialization
	void Start () {
		_statusCursor = StatusCursor.GetComponent<LockCursor>();

		try {
			_datePosition.xSign = this.gameObject.transform.position.x / Mathf.Abs( this.gameObject.transform.position.x );
		}
		catch {
			_datePosition.xSign = 0;
		}
		_datePosition.xMax = this.gameObject.transform.position.x + (100* _datePosition.xSign );

		
		try {
			_datePosition.ySign = this.gameObject.transform.position.y / Mathf.Abs( this.gameObject.transform.position.y );
		}
		catch {
			_datePosition.ySign = 0;
		}
		_datePosition.yMax = this.gameObject.transform.position.y + ( 100 * _datePosition.ySign );

		try {
			_datePosition.zSign = this.gameObject.transform.position.z / Mathf.Abs( this.gameObject.transform.position.z );
		}
		catch {
			_datePosition.zSign = 0;
		}
		_datePosition.zMax = this.gameObject.transform.position.z + ( 100 * _datePosition.zSign );
	}

	// Update is called once per frame
	void Update() {
		if (!_statusCursor._ctrlTrigger) {
			float axesValue = Input.GetAxis( "Mouse ScrollWheel" );
			if (axesValue != 0) {
				Camera obj = GetComponent<Camera>();
				if (obj != null) {
					obj.transform.position = ShiftVector( obj.transform.position, axesValue * _speed );
				}
			}
		}
	}

	private Vector3 ShiftVector(Vector3 baseVector, float shiftValue) {
		Vector3 newVector = new Vector3( 0, 0, 0 );				 

		if (baseVector.x != 0) {
			if (Mathf.Abs( baseVector.x + ( shiftValue * _datePosition.xSign ) ) > Mathf.Abs( _datePosition.xMax ) || Mathf.Abs( baseVector.x + ( shiftValue * _datePosition.xSign ) ) <_minValue)
				return baseVector;
			newVector.x = baseVector.x + ( shiftValue * _datePosition.xSign );
		}
		if (baseVector.y != 0) {
			if (Mathf.Abs( baseVector.y + ( shiftValue * _datePosition.ySign ) ) > Mathf.Abs( _datePosition.yMax ) || Mathf.Abs( baseVector.y + ( shiftValue * _datePosition.ySign ) ) < _minValue)
				return baseVector;
			newVector.y = baseVector.y + ( shiftValue * _datePosition.ySign );
		}
		if (baseVector.z != 0) {
			if (Mathf.Abs( baseVector.z + ( shiftValue * _datePosition.zSign ) ) > Mathf.Abs( _datePosition.zMax ) || Mathf.Abs( baseVector.z + ( shiftValue * _datePosition.zSign ) ) < _minValue)
				return baseVector;
			newVector.z = baseVector.z + ( shiftValue * _datePosition.zSign );
		}	

		return newVector;
	}
}									  