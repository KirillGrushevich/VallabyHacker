using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLikeParentImageColor : MonoBehaviour 
{

	private Image parentImage;
	private MeshRenderer rend;

	private void Start()
	{
		parentImage = transform.parent.gameObject.GetComponent<Image>();
		rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//Color clr = Color.white;
		//clr.a = 0;

		//if(parentImage.color != Color.white)
		 Color clr = parentImage.color;

		rend.material.SetColor("_Color", clr);
	}
}
