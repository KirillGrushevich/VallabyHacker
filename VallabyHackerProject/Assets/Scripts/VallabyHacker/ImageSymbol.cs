using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSymbol : SymbolBase {

	public Sprite[] sprites;

	public override void SetSymbol (HackSymbol symbol)
	{
		base.SetSymbol (symbol);
		GetComponent<Image> ().sprite = sprites[(int)symbol];
	}
}
