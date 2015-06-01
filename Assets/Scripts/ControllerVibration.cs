using UnityEngine;
using System.Collections;

public class ControllerVibration : MonoBehaviour {

	private string _distance;
	private int _shakes;

	void Awake()
	{
		InvokeRepeating("checkPosition",1,10);
	}

	private void checkPosition()
	{
		Debug.Log(_shakes);

		if(_distance == "close")
			_shakes = 3;
		else if(_distance == "medium")
			_shakes = 2;
		else if(_distance == "far")
			_shakes = 1;
		else
			return;
		
		InvokeRepeating("shake",1,1);
	}
	
	private void shake()
	{
		Handheld.Vibrate();
		_shakes -= 1;
		if(_shakes == 0)
			CancelInvoke("shake");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "close")
			_distance = "close";
		else if(other.gameObject.name == "medium")
			_distance = "medium";
		else
			_distance = "far";
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "close")
			_distance = "Medium";
		else if(other.gameObject.name == "medium")
			_distance = "far";
	}
}
