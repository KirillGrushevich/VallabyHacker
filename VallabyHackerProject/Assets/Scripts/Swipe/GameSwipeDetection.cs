using System;
using UnityEngine;

public class GameSwipeDetection : MonoBehaviour
{
    private Vector2 startPos;
    private bool isSwiped;
    public float minSwipeDistX = 5;

    public static Action<float> SwipeAction;



    void Update()
    {
        int direction = 0;

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    startPos = touch.position;
                    isSwiped = false;
                    break;

                case TouchPhase.Moved:
                    if(!isSwiped)
                    {
                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					if (swipeDistHorizontal > minSwipeDistX /100f * Screen.width)
                        {
                            direction = (int)Mathf.Sign(touch.position.x - startPos.x) * -1;
                            SwipeAction.Invoke(direction);
                            isSwiped = true;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiped = false;
                    break;
            }
        }
#endif

#if UNITY_EDITOR

        if (Input.GetKeyUp(KeyCode.LeftArrow)) SwipeAction.Invoke(1);
        if (Input.GetKeyUp(KeyCode.RightArrow)) SwipeAction.Invoke(-1);

#endif

    }
}
