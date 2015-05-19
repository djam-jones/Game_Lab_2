using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPattern : MonoBehaviour {

	public Color[] 		colors;//	= new Color[_red, _green, _blue, _yellow];

	private List<int> _pastCollection = new List<int>();

	private int 		_roundIndex;
	private int			_currentRound;
	private int[] 		_colorIndex;
	private float		_invokeTime = 1f;
	private float 		_repeatRate = 0.8f;

	private bool		_playersMove;

	private int 		_checker;

	public Light localLight;

	void Awake()
	{
		//als de round index 0 is word deze 1, maakt het mogelijk de eerste ronde altijd uit te voeren.
		if(_roundIndex == 0)
		{
			_roundIndex = 1;
		}

		localLight = GetComponent<Light>();
		turnLightOff();

		//start de loop functie voor de game.
		InvokeRepeating("ChangeColor", _invokeTime, _repeatRate);
	}

	void ChangeColor()
	{
		//stopt als hij het totaal aantal ronden heeft gehaald.
		if(_currentRound == _roundIndex)
		{
			CancelInvoke("ChangeColor");
			_currentRound = 0;
			return;
		}

		if(_currentRound == _pastCollection.Count)
		{
			int nextColor = Random.Range(0,4);
			_pastCollection.Add(nextColor);
			localLight.color = colors[nextColor];
			_checker = 0;
			Invoke("turnLightOff", 0.5f);
		}
		else
		{
			localLight.color = colors[_pastCollection[_currentRound]];
		}

		Invoke("turnLightOff", 0.5f);
		_currentRound++;
	}

	public void ButtonPressed(int inputButton)
	{
		if(inputButton == _pastCollection[_checker])
		{
			_checker++;

			if(_checker == _pastCollection.Count)
			{
				_roundIndex ++;
				InvokeRepeating("ChangeColor", _invokeTime, _repeatRate);
			}
			return;
		}

		Debug.Log("Wrong button");
	}

	void turnLightOff()
	{
		localLight.color = Color.white;
	}
}