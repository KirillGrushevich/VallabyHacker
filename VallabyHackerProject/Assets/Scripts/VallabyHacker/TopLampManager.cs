using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLampManager : MonoBehaviour {

	public Image[] images;

	private int currentLamp = 0;

	void EnableNextLamp (bool state) 
	{
		if (state) 
		{
			images [currentLamp].color = Color.green;
		} 
		else 
		{
			images [currentLamp].color = Color.red;
		}

		images [currentLamp].gameObject.SetActive (true);

		if (currentLamp < images.Length) 
		{
			currentLamp++;
		}
	}
}
