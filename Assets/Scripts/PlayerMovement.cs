using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private float _speed = 3f;
	private float _rotateSpeed = 150;

	private Vector3 _jumpVector = new Vector3(0, 7.5f, 0);
	private Rigidbody _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Movement();
	}

	private void Movement()
	{
		float _x = Input.GetAxis("P1_H_L_Joystick") * _speed * Time.deltaTime;
		float _y = Input.GetAxis("P1_H_R_Joystick") * _rotateSpeed * Time.deltaTime;
		float _z = Input.GetAxis("P1_V_L_Joystick") * _speed * Time.deltaTime;

		//Moving
		transform.Translate( new Vector3(_x, 0, _z) );
		transform.Rotate( new Vector3(0, _y, 0));



		if(Input.GetButtonDown("R2"))
		{
			_speed = (_speed * 3f);
		}
		else if(Input.GetButtonUp("R2"))
		{
			_speed = (_speed / 3f);
		}
	}
}
