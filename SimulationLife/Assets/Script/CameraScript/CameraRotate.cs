using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	public float _rotateX = 0;
	public float _rotateY = 0;

	public float _speedRotateX = 5f;
	public float _speedRotateY = 5f;

	public float _rotateMin = -90;
	public float _rotateMax = 90;

	[SerializeField] private GameObject StatusCursor;
	private LockCursor _statusCursor;
	// Use this for initialization
	void Start() {
		_statusCursor = StatusCursor.GetComponent<LockCursor>();
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
			body.freezeRotation = true;
	}

	// Update is called once per frame
	void Update() {
		if (!_statusCursor._ctrlTrigger) {
			_rotateX -= Input.GetAxis( "Mouse Y" ) * _speedRotateY;

			_rotateX = Mathf.Clamp( _rotateX, _rotateMin, _rotateMax );

			float delta = Input.GetAxis( "Mouse X" ) * _speedRotateX;
			_rotateY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3( _rotateX, _rotateY, 0 );
		} 
	}
}
