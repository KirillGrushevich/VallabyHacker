using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour {

	public void OnClick(float dir)
	{
		GameSwipeDetection.SwipeAction.Invoke (dir);
	}
}
