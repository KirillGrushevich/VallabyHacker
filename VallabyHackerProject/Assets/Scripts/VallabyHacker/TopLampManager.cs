using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLampManager : MonoBehaviour {

	public Image[] images;
	public float m_delay = 0;

	private int currentLamp = 0;

	public void EnableNextLamp (bool state) 
	{
		if (currentLamp < images.Length) 
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

			currentLamp++;
		}
	}

	public void SetEndGameLight(bool state)
	{
		StartCoroutine (EndGameCourotine (state));
	}

	IEnumerator EndGameCourotine(bool state)
	{
		foreach (Image _image in images)
		{
			yield return new WaitForSeconds (m_delay);

			if (state) 
			{
				_image.color = Color.green;	
			} 
			else 
			{
				_image.color = Color.red;	
			}

			_image.gameObject.SetActive (true);
		}
	}

	void Start()
	{
		SetEndGameLight (false);
	}
}
