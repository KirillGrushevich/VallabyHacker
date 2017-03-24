﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldElement : MonoBehaviour 
{

	[SerializeField]
	private SymbolBase m_Symbol;

	public SymbolBase SymbolBase
	{
		get{return m_Symbol;}
		set{m_Symbol = value;}
	}
}
