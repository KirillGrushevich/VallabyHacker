using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	public Image backgroundPauseImg;
	public GameObject buttons;
//	public Button exitGameButton;
//	public Button visitOurPageButton;
//	public Button rateUsButton;

	private bool isPressPause = false;

	public void OnClickPauseButton()
	{
		if (!isPressPause) 
		{
			Time.timeScale = 0;
			backgroundPauseImg.gameObject.SetActive (true);
			buttons.SetActive (true);
//			exitGameButton.gameObject.SetActive (true);
//			visitOurPageButton.gameObject.SetActive (true);
//			rateUsButton.gameObject.SetActive (true);
			isPressPause = true;
		} 
		else 
		{
			Time.timeScale = 1;
			isPressPause = false;
			backgroundPauseImg.gameObject.SetActive (false);
			buttons.SetActive (false);
//			exitGameButton.gameObject.SetActive (false);
//			visitOurPageButton.gameObject.SetActive (false);
//			rateUsButton.gameObject.SetActive (false);
		}
	}

	public void OnClickExitButton()
	{
		Application.Quit();
	}

	public void OnClickVisitButton()
	{
		Application.OpenURL ("https://www.facebook.com/Outback-Defender-1191809544270400/");
	}

	public void OnClickRateButton()
	{
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.KGF.OutbacHacker");
	}
}
