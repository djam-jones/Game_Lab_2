using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPattern : MonoBehaviour {

	//private Color 		_red 		= new Color(1, 0, 0);
	//private Color 		_green 		= new Color(0, 1, 0);
	//private Color 		_blue 		= new Color(0, 0, 1);
	//private Color 		_yellow 	= new Color(1, 1, 0);

	public Color[] 		colors;//	= new Color[_red, _green, _blue, _yellow];

	private List<int> _pastCollection = new List<int>();
	//public int[]		_pastCollection;

	private int 		_roundIndex;
	private int			_currentRound;
	private int[] 		_colorIndex;
	private float		_invokeTime = 1f;
	private float 		_repeatRate = 0.8f;

	private int 		_checker;

	public Light localLight;

	void Awake()
	{
		if(_roundIndex == 0)
		{
			_roundIndex = 1;
		}

		localLight = GetComponent<Light>();
		turnLightOff();
		InvokeRepeating("ChangeColor", _invokeTime, _repeatRate);
	}

	void ChangeColor()
	{
		if(_currentRound == _roundIndex)
		{
			CancelInvoke("ChangeColor");
			return;
		}

		int nextColor = Random.Range(0,4);

		_pastCollection.Add(nextColor);

		Debug.Log(_pastCollection.Count);

		localLight.color = colors[nextColor];
		Invoke("turnLightOff", 0.5f);

		_currentRound++;
	}

	public void ButtonPressed(int inputButton)
	{
		if(inputButton == _pastCollection[_checker])
		{
			_checker ++;
			Debug.Log("correct");

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