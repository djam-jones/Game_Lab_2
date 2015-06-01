using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private float _speed = 10;
	private bool _onGround;

	private Vector3 _jumpVector = new Vector3(0, 7.5f, 0);
	private Rigidbody _rigidbody;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Movement();
		print("Player On Ground is " + _onGround);
	}

	private void Movement()
	{
		float _x = Input.GetAxis("P1_H_L_Joystick") * _speed * Time.deltaTime;
		float _z = Input.GetAxis("P1_V_L_Joystick") * _speed * Time.deltaTime;

		//Moving
		transform.Translate( new Vector3(_x, 0, _z) );

		//Jump
		if(Input.GetButtonDown("Cross") && _onGround)
		{
			_rigidbody.velocity = _jumpVector;
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Ground")
		{
			_onGround = true;
		}
		else if(c.gameObject.tag != "Ground")
		{
			_onGround = false;
		}
	}

}
