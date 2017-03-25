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

	private int stage;
	private bool[] stagesEquals;

	Coroutine hackCoroutine;
	bool isBreak;

	// Use this for initialization
	private void Start () 
	{
		hackCoroutine = null;
		missCounter = -1;
		winCounter = 0;
		stage = 0;
        GameSwipeDetection.SwipeAction += swipeEvent;		

		stagesEquals = RandomArray.GetRandomArray(10);
        
	}

    void OnDestroy()
    {
        GameSwipeDetection.SwipeAction -= swipeEvent;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(hackCoroutine == null && Input.GetMouseButtonDown(0))
		{
			hackCoroutine =  StartCoroutine(hackRoutine(0.5f));
		}					
	}

	private void generateSymbols()
	{
		if(stage < 5)
		{
			m_Field.GenerateStage(m_BaseSymbol.GetComponent<SymbolBase>(), Random.Range(0, 8), stagesEquals[stage]);
			stage++;
		}
	}

    private void swipeEvent(float dir)
    {
        if (!isBreak)
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

            if (missCounter >= 2)
            {
                endHack(false);
                return;
            }

            if (winCounter + missCounter >= 5)
            {
                endHack(true);
                return;
            }

            m_Field.ClearField();
            isBreak = true;
        }


    }

    private void endHack(bool isVictory)
	{
			print(isVictory);
			StopAllCoroutines();
			m_Field.ClearField();
	}

    private IEnumerator hackRoutine(float timer)
    {
		yield return new WaitForSeconds(timer);
		generateSymbols();

        while (true)
        {
            float _timer = 3f;
            while (_timer > 0)
            {
				if(isBreak)
				{
					m_timer.text = "";
					yield return new WaitForSeconds(2f);
					isBreak = false;
					generateSymbols();
					_timer = 3f;
				}
				else
				{
               		_timer -= Time.deltaTime;
 					double b;
 					b = System.Math.Round(_timer,2);
					m_timer.text = b.ToString();
					yield return null;
				}

            }
			
            m_timer.text = "";
            missCounter++;
            if (missCounter > 1)
            {
                endHack(false);
                break;
            }

			m_Field.ClearField();
			yield return new WaitForSeconds(2f);
			generateSymbols();

        }
    }
}
