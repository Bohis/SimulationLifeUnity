using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] Camera [] _arrayCameras;
	private int _indexCamer;

	[SerializeField] private GameObject StatusCursor;
	private LockCursor _statusCursor;

	private int NextIndex() {
		if (_indexCamer == _arrayCameras.Length - 1) {
			_indexCamer = 0;
		}
		else {
			++_indexCamer;
		}
		return _indexCamer;
	}

	private int PreviousIndex() {
		if (_indexCamer == 0) {
			_indexCamer = _arrayCameras.Length - 1;
		}
		else {
			--_indexCamer;
		}
		return _indexCamer;
	}

	private int StartArray() {
		_indexCamer = 0;
		return _indexCamer;
	}

	private int EndArray() {
		_indexCamer = _arrayCameras.Length - 1;
		return _indexCamer;
	}

	// Use this for initialization
	void Start() {
		_statusCursor = StatusCursor.GetComponent<LockCursor>();
		_indexCamer = 0;
		foreach (Camera s in _arrayCameras) {
			s.gameObject.SetActive( false );
		}
		_arrayCameras [ _indexCamer ].gameObject.SetActive( true );
	}

	// Update is called once per frame
	void Update() {		
		if (!_statusCursor._ctrlTrigger) {
			if (Input.GetKeyDown( KeyCode.RightArrow ) || Input.GetKeyDown( KeyCode.D )) {
				_arrayCameras [ _indexCamer ].gameObject.SetActive( false );
				_arrayCameras [ NextIndex() ].gameObject.SetActive( true );
				goto end;
			}

			if (Input.GetKeyDown( KeyCode.LeftArrow ) || Input.GetKeyDown( KeyCode.A )) {
				_arrayCameras [ _indexCamer ].gameObject.SetActive( false );
				_arrayCameras [ PreviousIndex() ].gameObject.SetActive( true );
				goto end;
			}

			if (Input.GetKeyDown( KeyCode.UpArrow ) || Input.GetKeyDown( KeyCode.W )) {
				_arrayCameras [ _indexCamer ].gameObject.SetActive( false );
				_arrayCameras [ StartArray() ].gameObject.SetActive( true );
				goto end;
			}

			if (Input.GetKeyDown( KeyCode.DownArrow ) || Input.GetKeyDown( KeyCode.S )) {
				_arrayCameras [ _indexCamer ].gameObject.SetActive( false );
				_arrayCameras [ EndArray() ].gameObject.SetActive( true );
				goto end;
			}

end:
			return;
		}
	}
}
