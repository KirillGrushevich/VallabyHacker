using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VallabyHackerController : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_BaseSymbol;

	[SerializeField]
	private VallabyHackerGameField m_Field;

    [SerializeField]
    private Image m_resultImage;

	// Use this for initialization
	void Start () 
	{
		 generateSymbols();
        GameSwipeDetection.SwipeAction += swipeEvent;
        
	}

    void OnDestroy()
    {
        GameSwipeDetection.SwipeAction -= swipeEvent;
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
        bool isUnique = true;
        if (Random.Range(0, 2) == 1)
            isUnique = false;

		m_Field.GenerateStage(m_BaseSymbol.GetComponent<SymbolBase>(), Random.Range(0, 15), isUnique);
	}

    private void swipeEvent(float dir)
    {
        bool isEquals = m_Field.isIsEquals();
        Color clr = Color.red;
        if (dir < 0 && isEquals || dir > 0 && !isEquals)
            clr = Color.green;

        m_resultImage.color = clr;    

        generateSymbols();
    }


}
