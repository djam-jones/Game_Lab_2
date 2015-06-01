using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float _rotateSpeed = 120f;

	void Update()
	{
		float _x = Input.GetAxis("P1_V_R_Joystick") * _rotateSpeed * Time.deltaTime;

		transform.Rotate(new Vector3( -_x, 0, 0 ));
	}

}
