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

    [SerializeField]
    private GameObject m_Background;

    [SerializeField]
    private GameObject m_WinText;
    [SerializeField]
    private GameObject m_LooseText;
    [SerializeField]
    private GameObject m_EndGameWinText;
    [SerializeField]
    private GameObject m_EndGameDefeateText;

    private List<GameObject> gameObjects = new List<GameObject>();
    private List<GameObject> playerObjects = new List<GameObject>();

    private void Start()
    {
        m_Background.SetActive(false);
    }

    public void GenerateStage(SymbolBase symbol, int key, bool isUnique)
	{
        ClearField(true);

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

    public void ClearField(bool isActive)
    {
         m_Background.SetActive(isActive);
        foreach(GameObject obj in gameObjects)
        {
            if(!obj.GetComponent<ChangeImageAlfa>())
               Destroy(obj);
        }

        foreach (GameObject obj in playerObjects)
        {
            if(!obj.GetComponent<ChangeImageAlfa>())
               Destroy(obj);
        }
        gameObjects = new List<GameObject>();
        playerObjects = new List<GameObject>();
    }

    public bool IsEquals()
    {
        foreach(GameObject fieldObj in gameObjects)
        {
            foreach(GameObject playerObj in playerObjects)
            {
                SymbolBase p = playerObj.GetComponent<SymbolBase>();
                SymbolBase f = fieldObj.GetComponent<SymbolBase>();

                if (p.Symbol == f.Symbol)
                {
                    playerObj.AddComponent<ChangeImageAlfa>();
                    fieldObj.AddComponent<ChangeImageAlfa>();
                    return true;
                }                    
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
				int newNm = Random.Range(0, 8);
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
                int newNm = Random.Range(0, 8);
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

    public void ActivateResultText(bool isPositive, bool isEnd)
    {
        if (!isEnd)
        {
            if (isPositive)
            {
                m_WinText.SetActive(true);
                DisableOnTime dis = m_WinText.AddComponent<DisableOnTime>();
                dis.disableAt(2f);
                return;
            }

            m_LooseText.SetActive(true);
            DisableOnTime _dis = m_LooseText.AddComponent<DisableOnTime>();
            _dis.disableAt(2f);
            return;
        }

        m_LooseText.SetActive(false);
        m_WinText.SetActive(false);

        if (isPositive)
        {
            m_EndGameWinText.SetActive(true);
            DisableOnTime dis = m_EndGameWinText.AddComponent<DisableOnTime>();
            dis.disableAt(9999f);
            return;
        }

        m_EndGameDefeateText.SetActive(true);
        DisableOnTime _disa = m_EndGameDefeateText.AddComponent<DisableOnTime>();
        _disa.disableAt(9999f);


    }


}
