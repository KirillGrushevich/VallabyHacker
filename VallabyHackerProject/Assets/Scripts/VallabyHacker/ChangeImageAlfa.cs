using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageAlfa : MonoBehaviour {

	private Color color;

	void Start () 
	{
		color = GetComponent<Image> ().color;
		StartCoroutine (AlfaCoroutine());
	}

	IEnumerator AlfaCoroutine()
	{
		float counter = 0.5f;

		while (counter > 0) 
		{
			color.a -= 1.5f * Time.deltaTime;
			GetComponent<Image> ().color = color;
			Debug.Log (color.a);
			counter -= Time.deltaTime;
			yield return null;
		}

		while (counter <= 0.5f) 
		{
			color.a += 1.5f * Time.deltaTime;
			GetComponent<Image> ().color = color;
			counter += Time.deltaTime;
			yield return null;
		}

		DestroyObject (this);
	}
}
