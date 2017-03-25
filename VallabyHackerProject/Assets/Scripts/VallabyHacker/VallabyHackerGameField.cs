using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VallabyHackerGameField : MonoBehaviour 
{

	[SerializeField]
	private FieldElement[] m_GameElements;

	[SerializeField]
	private FieldElement[] m_PlayerElements;

    private List<GameObject> gameObjects = new List<GameObject>();
    private List<GameObject> playerObjects = new List<GameObject>();

    public void GenerateStage(SymbolBase symbol, int key, bool isUnique)
	{
        foreach(GameObject obj in gameObjects)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in playerObjects)
        {
            Destroy(obj);
        }
        gameObjects = new List<GameObject>();
        playerObjects = new List<GameObject>();

    int[] numbers = randomizer(m_GameElements.Length, key);

        //Game field
        for (int i = 0; i < m_GameElements.Length; i++)
        {
            m_GameElements[i].gameObject.SetActive(false);
            //m_GameElements[i].Symbol = symbol;
            GameObject obj = Instantiate(symbol.gameObject, m_GameElements[i].transform.position, m_GameElements[i].transform.rotation, m_GameElements[i].transform.parent);
            gameObjects.Add(obj);
            obj.GetComponent<SymbolBase>().SetSymbol((HackSymbol)numbers[i]);
        }

        //PlayerField
		numbers = randomizer(m_PlayerElements.Length, key);
        if(isUnique)
            numbers = randomizer(m_PlayerElements.Length, numbers);

        for (int i = 0; i < m_PlayerElements.Length; i++)
        {
            m_PlayerElements[i].gameObject.SetActive(false);
            GameObject obj = Instantiate(symbol.gameObject, m_PlayerElements[i].transform.position, m_PlayerElements[i].transform.rotation, m_PlayerElements[i].transform.parent);
            playerObjects.Add(obj);
            obj.GetComponent<SymbolBase>().SetSymbol((HackSymbol)numbers[i]);
        }
    }

    public bool isIsEquals()
    {
        foreach(GameObject fieldObj in gameObjects)
        {
            foreach(GameObject playerObj in playerObjects)
            {
                SymbolBase p = playerObj.GetComponent<SymbolBase>();
                SymbolBase f = fieldObj.GetComponent<SymbolBase>();

                if (p.Symbol == f.Symbol)
                    return true;
            }
        }

        return false;
    }


    private int[] randomizer(int lenght, int key)
	{
		int[] arr = new int[lenght];
		for (int i=0; i<lenght; i++)
		{
			int nm = key;
            List<int> generated = new List<int>();
            generated.Add(key);
			while(true)
			{
				int newNm = Random.Range(0, 15);
                if(generated.Contains(newNm))
                {
                    continue;
                }
                generated.Add(newNm);
                nm = newNm;
                break;
			}
			arr[i] = nm;
 		}

		arr[Random.Range(0, lenght)] = key;
		return arr;
	}

    private int[] randomizer(int lenght, int[] keys)
    {
        int[] arr = new int[lenght];

        for (int i = 0; i < lenght; i++)
        {
            int nm = 0;
            List<int> generated = new List<int>(keys);
            while (true)
            {
                int newNm = Random.Range(0, 15);
                if (generated.Contains(newNm))
                {
                    continue;
                }
                generated.Add(newNm);
                nm = newNm;
                break;
            }
            arr[i] = nm;
        }
        return arr;
    }


}
