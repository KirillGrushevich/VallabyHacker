using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

	public TextAsset inputText;

	private Text text;
	private string loadText = "Good news evereone!!!\n" +
		"__________Loading________\n" +
		"I make his load stuff!!\n" +
		"Yyyyyyyeeepi!!\n" +
		"asdr34543&@sefjfs_23!!\n" +
		"23456_34543+@4535\n"+
		"sefwerrt345534\n"+
		"Seft test is complited";

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
