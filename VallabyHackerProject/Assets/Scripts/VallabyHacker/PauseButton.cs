using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	public Image backgroundPauseImg;
	public Button exitGameButton;
	public Button visitOurPageButton;

	private bool isPressPause = false;

	public void OnClickPauseButton()
	{
		if (!isPressPause) 
		{
			Time.timeScale = 0;
			backgroundPauseImg.gameObject.SetActive (true);
			exitGameButton.gameObject.SetActive (true);
			visitOurPageButton.gameObject.SetActive (true);
			isPressPause = true;
		} 
		else 
		{
			Time.timeScale = 1;
			isPressPause = false;
			backgroundPauseImg.gameObject.SetActive (false);
			exitGameButton.gameObject.SetActive (false);
			visitOurPageButton.gameObject.SetActive (false);
		}
	}

	public void OnClickExitButton()
	{
		Application.Quit();
	}

	public void OnClickVisitButton()
	{
		Application.OpenURL ("https://vk.com/away.php?to=https%3A%2F%2Fwww.facebook.com%2FOutback-Defender-1191809544270400%2F");
	}
}
