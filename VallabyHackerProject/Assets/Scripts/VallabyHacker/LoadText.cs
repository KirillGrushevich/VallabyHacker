using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour 
{
	public TextAsset inputText;
	private Text text;

	[SerializeField]
	private bool isDestroyOnTouch;

	[SerializeField]
	private float m_delayTime = 1.5f;

	void OnEnable () 
	{
		text = GetComponent<Text> ();
		StartCoroutine (AnimateText ());
	}

	void Update()
	{
		if(isDestroyOnTouch && Input.GetMouseButtonDown(0))
		{
			Destroy(gameObject);
		}
	}

	IEnumerator AnimateText()
	{
		yield return new WaitForSeconds(m_delayTime);
        for (int i = 0; i < inputText.text.Length; i++)
        {
            text.text = inputText.text.Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
	}

}
