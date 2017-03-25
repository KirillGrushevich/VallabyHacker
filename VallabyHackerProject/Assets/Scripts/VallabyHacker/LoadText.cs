using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

	public TextAsset inputText;

	private Text text;
	private string loadText = "Loading...\n" +
	                          "\n" +
	                          ".../»\n" +
	                          "Welcome to Wallaby Electronic System!\n" +
	                          "Please, enter your graphical password.\n...";

	void Start () 
	{
		text = GetComponent<Text> ();
		StartCoroutine (AnimateText ());
	}

	IEnumerator AnimateText()
	{
		for (int i = 0; i < loadText.Length; i++) 
		{
			if (inputText == null) 
			{
				text.text = loadText.Substring (0, i);
			} 
			else 
			{
				text.text = inputText.text.Substring (0, i);
			}
			yield return new WaitForSeconds (.03f);
		}
	}

}
