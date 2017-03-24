using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VallabyHackerGameField : MonoBehaviour 
{

	[SerializeField]
	private FieldElement[] m_GameElements;

	[SerializeField]
	private FieldElement[] m_PlayerElements;

	public void GenerateStage(SymbolBase symbol, int key)
	{
		int[] numbers = randomizer(m_GameElements.Length, key);
		foreach(int nm in numbers)
			print(nm);
		numbers = randomizer(m_PlayerElements.Length, key);
				foreach(int nm in numbers)
			print(nm);
	}

	private int[] randomizer(int lenght, int key)
	{
		int[] arr = new int[lenght];
		for (int i=0; i<lenght; i++)
		{
			int nm = key;
			while(nm == key)
			{
				nm = Random.Range(0, 15);
			}
			arr[i] = nm;
		}

		arr[Random.Range(0, lenght)] = key;
		return arr;
	}


}
