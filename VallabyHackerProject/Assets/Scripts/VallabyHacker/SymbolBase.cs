using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SymbolBase : MonoBehaviour {

	private HackSymbol symbol;

	public virtual void Init (){}

	public virtual void SetSymbol (HackSymbol symbol)
	{
		this.symbol = symbol;
	}

	public virtual bool IsEquals(HackSymbol symbol)
	{
		return this.symbol == symbol;
	}
		
}
