using UnityEngine;

public class DisableOnTime : MonoBehaviour 
{

	float timer;
	// Use this for initialization
	public void disableAt (float time) 
	{
		timer = Time.time + time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timer)
		{
			gameObject.SetActive(false);
			Destroy(this);
		}
	}
}
