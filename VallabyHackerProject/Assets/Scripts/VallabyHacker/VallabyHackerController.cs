using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VallabyHackerController : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_BaseSymbol;

	[SerializeField]
	private VallabyHackerGameField m_Field;

	// Use this for initialization
	void Start () 
	{
		 generateSymbols();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartMinigame()
	{

	}

	private void generateSymbols()
	{
		m_Field.GenerateStage(m_BaseSymbol.GetComponent<SymbolBase>(), Random.Range(0, 15));
	}


}
