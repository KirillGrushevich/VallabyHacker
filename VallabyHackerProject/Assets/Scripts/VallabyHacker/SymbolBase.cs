using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SymbolBase : MonoBehaviour {

	private HackSymbol symbol;

	protected abstract void Init ();

	protected void SetSymbol (HackSymbol symbol)
	{
		this.symbol = symbol;
	}

	protected bool IsEquals(HackSymbol symbol)
	{
		return this.symbol == symbol;
	}
		
}
