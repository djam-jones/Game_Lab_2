using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float _speed = 10.0F;
	private float _rotationSpeed = 100.0F;

	private string _distance;
	private int _shakes;

	void awake()
	{
		InvokeRepeating("checkPosition",1,10);
	}

	void Update() 
	{
		float translation = Input.GetAxis("Vertical") * _speed;
		float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
		
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}
}