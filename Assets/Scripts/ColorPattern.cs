using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPattern : MonoBehaviour {

	private Color 		_red 		= new Color(1, 0, 0);
	private Color 		_green 		= new Color(0, 1, 0);
	private Color 		_blue 		= new Color(0, 0, 1);
	private Color 		_yellow 		= new Color(1, 1, 0);

	private int 		_roundIndex;
	private int[] 		_colorIndex;
	private float		_invokeTime = 0.5f;
	private float 		_repeatRate = 1f;

	public Light localLight;

	void Awake()
	{
		localLight = GetComponent<Light>();
		localLight.color = Color.white;
		//InvokeRepeating("ChangeColor", _invokeTime, _repeatRate);
	}

	void ChangeColor()
	{

	}

}