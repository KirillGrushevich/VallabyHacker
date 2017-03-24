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

		GetComponent<Image> ().color = color;
	}

	void Update()
	{
		if (Input.anyKeyDown)
			SetSymbol (HackSymbol.Element10);
	}
}
