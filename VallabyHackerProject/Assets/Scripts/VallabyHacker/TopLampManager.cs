using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLampManager : MonoBehaviour {

	public Image[] images;
	public float m_delay = 0;

	private int currentLamp = 0;

	public void EnableNextLamp (bool state) 
	{
		if (currentLamp < images.Length) 
		{
			if (state) 
			{
				images [currentLamp].color = Color.green;
			} 
			else 
			{
				images [currentLamp].color = Color.red;
			}

			images [currentLamp].gameObject.SetActive (true);

			currentLamp++;
		}
	}

	public void SetEndGameLight(bool state)
	{
		StartCoroutine (EndGameCourotine (state));
	}

    IEnumerator EndGameCourotine(bool state)
    {
        while (true)
        {
            foreach (Image _image in images)
            {
                if (state)
                {
                    _image.color = Color.green;
                }
                else
                {
                    _image.color = Color.red;
                }

                _image.gameObject.SetActive(true);
				yield return new WaitForSeconds(0.1f);

            }

			foreach (Image _image in images) 
			{
				_image.gameObject.SetActive(false);
				yield return new WaitForSeconds(0.1f);
			}

            yield return null;
        }
    }
}
