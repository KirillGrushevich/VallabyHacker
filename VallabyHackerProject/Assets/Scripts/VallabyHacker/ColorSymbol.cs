using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSymbol : SymbolBase {

	private Color color;

	public override void SetSymbol (HackSymbol symbol)
	{
		base.SetSymbol (symbol);

		color = HackSymbol_Color.Colors [(int)symbol];
//		Debug.Log ((int)symbol);

		GetComponent<Image> ().color = color;
//		Debug.Log (GetComponent<Image> ().color);
	}

	void Update()
	{
//		if (Input.GetButtonDown ("Fire1")) {
//			SetSymbol (HackSymbol.Element7);
//		}
	}
}
