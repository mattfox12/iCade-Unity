using System;
using UnityEngine;

public class ICade : MonoBehaviour {
	static public ICade instance = null;
	
	public event Action SignalICadeConnect;
	public event Action SignalICadeDisconnect;

	// connected, use to hide/show on-screen alternate buttons
	private bool _connected;
	private float _timeout;
	private float _maxTime = 60.0f;
	
	// d-pad
	private bool _left = false;
	private bool _leftOld = false;
	private bool _right = false;
	private bool _rightOld = false;
	private bool _up = false;
	private bool _upOld = false;
	private bool _down = false;
	private bool _downOld = false;
	
	// start/select
	private bool _select = false;
	private bool _selectOld = false;
	private bool _start = false;
	private bool _startOld = false;
	
	// shoulder buttons
	private bool _l = false;
	private bool _lOld = false;
	private bool _r = false;
	private bool _rOld = false;
	
	// buttons
	private bool _a = false; // bottom right
	private bool _aOld = false;
	private bool _b = false; // bottom left
	private bool _bOld = false;
	private bool _y = false; // top left
	private bool _yOld = false;
	private bool _x = false; // top right
	private bool _xOld = false;
	
	// Use this for initialization
	private void Awake () 
	{
		instance = this;
	}
	
	void LateUpdate() {
		// update old values
		_leftOld = _left;
		_rightOld = _right;
		_upOld = _up;
		_downOld = _down;
		_startOld = _start;
		_selectOld = _select;
		_lOld = _l;
		_rOld = _r;
		_aOld = _a;
		_bOld = _b;
		_xOld = _x;
		_yOld = _y;
	}
	
	// Update is called once per frame
	public void Update () {
		if (_timeout > 0) {
			_timeout -= Time.deltaTime;
			
			if (_timeout <= 0) {
				_connected = false;
				
				// send notification
				if (SignalICadeDisconnect != null) SignalICadeDisconnect();
			}
		}
		
		// left
		if (Input.GetKey(KeyCode.A)) _left = true;
		if (Input.GetKey(KeyCode.Q)) _left = false;
		
		// right
		if (Input.GetKey(KeyCode.D)) _right = true;
		if (Input.GetKey(KeyCode.C)) _right = false;
		
		// up
		if (Input.GetKey(KeyCode.W)) _up = true;
		if (Input.GetKey(KeyCode.E)) _up = false;
		
		// down
		if (Input.GetKey(KeyCode.X)) _down = true;
		if (Input.GetKey(KeyCode.Z)) _down = false;
		
		// start
		if (Input.GetKey(KeyCode.U)) _start = true;
		if (Input.GetKey(KeyCode.F)) _start = false;
		
		// select
		if (Input.GetKey(KeyCode.Y)) _select = true;
		if (Input.GetKey(KeyCode.T)) _select = false;
		
		// l
		if (Input.GetKey(KeyCode.H))_l = true;
		if (Input.GetKey(KeyCode.R)) _l = false;
		
		// r
		if (Input.GetKey(KeyCode.J)) _r = true;
		if (Input.GetKey(KeyCode.N)) _r = false;
		
		// a
		if (Input.GetKey(KeyCode.L)) _a = true;
		if (Input.GetKey(KeyCode.V)) _a = false;
		
		// b
		if (Input.GetKey(KeyCode.K)) _b = true;
		if (Input.GetKey(KeyCode.P)) _b = false;
		
		// y
		if (Input.GetKey(KeyCode.I)) _y = true;
		if (Input.GetKey(KeyCode.M)) _y = false;
		
		// x
		if (Input.GetKey(KeyCode.O)) _x = true;
		if (Input.GetKey(KeyCode.G)) _x = false;
	}
	
	
	private void OnApplicationQuit()
	{
		instance = null;
	}
	
	private void OnDestroy()
	{
		instance = null;	
	}
	
	public bool isConnected() {
		return _connected;
	}
	
	public void iCadeKeyPress(string message) {
		if (_connected == false) {
			// send notification
			if (SignalICadeConnect != null) SignalICadeConnect();
		}
		_connected = true;
		_timeout = _maxTime;
		
		this.Press(message);
	}
	
	public void Press(string message) {
		//Debug.Log("iCade Key Press: " + message);
		switch (message) {
		case "DOWN":
			_down = true;
			break;
		case "UP":
			_up = true;
			break;
		case "RIGHT":
			_right = true;
			break;
		case "LEFT":
			_left = true;
			break;
		case "SELECT":
			_select = true;
			break;
		case "START":
			_start = true;
			break;
		case "A":
			_a = true;
			break;
		case "B":
			_b = true;
			break;
		case "Y":
			_y = true;
			break;
		case "X":
			_x = true;
			break;
		case "L":
			_l = true;
			break;
		case "R":
			_r = true;
			break;
		}
	}
	
	public void iCadeKeyRelease(string message) {
		_connected = true;
		_timeout = _maxTime;
		
		this.Release (message);
	}
	
	public void Release(string message) {
		//Debug.Log("iCade Key Release: " + message);
		switch (message) {
		case "DOWN":
			_down = false;
			break;
		case "UP":
			_up = false;
			break;
		case "RIGHT":
			_right = false;
			break;
		case "LEFT":
			_left = false;
			break;
		case "SELECT":
			_select = false;
			break;
		case "START":
			_start = false;
			break;
		case "A":
			_a = false;
			break;
		case "B":
			_b = false;
			break;
		case "Y":
			_y = false;
			break;
		case "X":
			_x = false;
			break;
		case "L":
			_l = false;
			break;
		case "R":
			_r = false;
			break;
		}
	}
	
	public bool justPressed(string name) 
	{
		switch (name) {
			case "LEFT":
				if (_left && !_leftOld) {
					return true;
				}
				break;
			case "RIGHT":
				if (_right && !_rightOld) {
					return true;
				}
				break;
			case "UP":
				if (_up && !_upOld) {
					return true;
				}
				break;
			case "DOWN":
				if (_down && !_downOld) {
					return true;
				}
				break;
			case "START":
				if (_start && !_startOld) {
					return true;
				}
				break;
			case "SELECT":
				if (_select && !_selectOld) {
					return true;
				}
				break;
			case "A":
				if (_a && !_aOld) {
					return true;
				}
				break;
			case "B":
				if (_b && !_bOld) {
					return true;
				}
				break;
			case "Y":
				if (_y && !_yOld) {
					return true;
				}
				break;
			case "X":
				if (_x && !_xOld) {
					return true;
				}
				break;
			case "L":
				if (_l && !_lOld) {
					return true;
				}
				break;
			case "R":
				if (_r && !_rOld) {
					return true;
				}
				break;
		}
		
		return false;
	}
	
	public bool justReleased(string name)
	{
		switch (name) {
			case "LEFT":
				if (!_left && _leftOld) {
					return true;
				}
				break;
			case "RIGHT":
				if (!_right && _rightOld) {
					return true;
				}
				break;
			case "UP":
				if (!_up && _upOld) {
					return true;
				}
				break;
			case "DOWN":
				if (!_down && _downOld) {
					return true;
				}
				break;
			case "START":
				if (!_start && _startOld) {
					return true;
				}
				break;
			case "SELECT":
				if (!_select && _selectOld) {
					return true;
				}
				break;
			case "A":
				if (!_a && _aOld) {
					return true;
				}
				break;
			case "B":
				if (!_b && _bOld) {
					return true;
				}
				break;
			case "Y":
				if (!_y && _yOld) {
					return true;
				}
				break;
			case "X":
				if (!_x && _xOld) {
					return true;
				}
				break;
			case "L":
				if (!_l && _lOld) {
					return true;
				}
				break;
			case "R":
				if (!_r && _rOld) {
					return true;
				}
				break;
		}
		
		return false;
	}
	
	public bool isDown(string name) 
	{
		switch (name) {
			case "LEFT":
				if (_left) {
					return true;
				}
				break;
			case "RIGHT":
				if (_right) {
					return true;
				}
				break;
			case "UP":
				if (_up) {
					return true;
				}
				break;
			case "DOWN":
				if (_down) {
					return true;
				}
				break;
			case "START":
				if (_start) {
					return true;
				}
				break;
			case "SELECT":
				if (_select) {
					return true;
				}
				break;
			case "A":
				if (_a) {
					return true;
				}
				break;
			case "B":
				if (_b) {
					return true;
				}
				break;
			case "Y":
				if (_y) {
					return true;
				}
				break;
			case "X":
				if (_x) {
					return true;
				}
				break;
			case "L":
				if (_l) {
					return true;
				}
				break;
			case "R":
				if (_r) {
					return true;
				}
				break;
			case "ANY":
				if (_a || _b || _x || _y || _start || _select || _l || _r || _left || _right || _up || _down) {
					return true;
				}
				break;
		}
		
		return false;
	}
}
