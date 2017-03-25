using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSwipeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameSwipeDetection.SwipeAction += move;
	}
	
	// Update is called once per frame
	void OnDestroy () {
        GameSwipeDetection.SwipeAction -= move;
    }

    private void move(float dir)
    {
        transform.Translate(transform.right * dir);
    }
}
