using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VallabyHackerController : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_BaseSymbol;

	[SerializeField]
	private VallabyHackerGameField m_Field;

    [SerializeField]
    private TopLampManager m_Lamps;

	[SerializeField]
	private Text m_timer;

	private int missCounter = 0;
	private int winCounter = 0;

	private int stage;
	private bool[] stagesEquals;

	Coroutine hackCoroutine;
	bool isBreak;

	bool isEnded;

	// Use this for initialization
	private void Start () 
	{
		hackCoroutine = null;
		missCounter = 0;
		winCounter = 0;
		stage = 0;
		isEnded = false;
        GameSwipeDetection.SwipeAction += swipeEvent;		

		stagesEquals = RandomArray.GetRandomArray(10);

		hackCoroutine =  StartCoroutine(hackRoutine(0.5f));
        
	}

    void OnDestroy()
    {
        GameSwipeDetection.SwipeAction -= swipeEvent;
    }
	
	// Update is called once per frame
	void Update () 
	{

		if(isEnded && Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            bool isEquals = m_Field.IsEquals();
            bool isComplete = false;
            if (dir < 0 && isEquals || dir > 0 && !isEquals)
            {
                isComplete = true;
                winCounter++;
				m_Field.ActivateResultText(true, false);
            }
            else 
			{
				missCounter++;
				m_Field.ActivateResultText(false, false);
			}

            m_Lamps.EnableNextLamp(isComplete);

            if (isEnd())
            {				
                return;
            }

            m_Field.ClearField(false);
            isBreak = true;
        }
    }

    private void endHack(bool isVictory)
	{
			StopAllCoroutines();
			m_Field.ClearField(false);
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
			m_Field.ActivateResultText(false, false);

            if (!isEnd())
            {
                m_Lamps.EnableNextLamp(false);
                m_Field.ClearField(false);
                yield return new WaitForSeconds(2f);
                generateSymbols();
            }
        }
    }

    private bool isEnd()
    {
        if (missCounter > 1)
        {
            endHack(false);
			m_Lamps.SetEndGameLight(false);
			//StopAllCoroutines();
			m_timer.enabled = false;
			m_Field.ActivateResultText(false, true);
			isEnded = true;
            return true;
        }

        if (winCounter + missCounter >= 5)
        {
            endHack(true);
			m_Lamps.SetEndGameLight(true);
			m_timer.enabled = false;
			m_Field.ActivateResultText(true, true);			
            return true;
        }
        return false;
    }
}
