using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SymbolBase : MonoBehaviour {

	protected abstract void Init ();

	protected abstract void SetSymbol (HackSymbol symbol);

	protected abstract bool IsEquals();
		
}
