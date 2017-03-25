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

	[SerializeField]
	private Text m_timer;

	private int missCounter = -1;
	private int winCounter = 0;

	// Use this for initialization
	private void Start () 
	{
		missCounter = -1;
		winCounter = 0;
        GameSwipeDetection.SwipeAction += swipeEvent;
		StartCoroutine(waitRoutine(3f));
        
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
        if (missCounter >= 0)
        {
            bool isEquals = m_Field.isIsEquals();
            Color clr = Color.red;
            if (dir < 0 && isEquals || dir > 0 && !isEquals)
			{
 				clr = Color.green;
				winCounter++;
			} 
			else missCounter++;
            m_resultImage.color = clr;
			if(winCounter >=3)
			{
				endHack(true);
				return;
			}

			if(missCounter > 1)
			{
				endHack(false);
				return;
			}

			StopCoroutine("hackRoutine");
			m_Field.ClearField();
			StartCoroutine(waitRoutine(2f));
        }

    }

	private void endHack(bool isVictory)
	{
			print(isVictory);
			StopCoroutine("hackRoutine");
			m_Field.ClearField();
	}

    private IEnumerator hackRoutine()
    {
        while (true)
        {
            float _timer = 3f;
            while (_timer > 0)
            {
               	_timer -= Time.deltaTime;
 				double b;
 				b = System.Math.Round(_timer,2);
				m_timer.text = b.ToString();
				yield return null;

            }
            m_timer.text = "0";
            missCounter++;
            if (missCounter > 1)
            {
                endHack(false);
                break;
            }

			StartCoroutine(waitRoutine(3f));

        }
    }

	private IEnumerator waitRoutine(float timer)
	{
		yield return new WaitForSeconds(timer);
		StartCoroutine("hackRoutine");
		generateSymbols();
		if(missCounter < 0)
			missCounter = 0;
	}


}
