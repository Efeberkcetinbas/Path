using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchManager : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private float dragDistance;

    void Start()
    {
        dragDistance=Screen.height*15/100;
    }

    void Update()
    {
        CheckMove();
    }

    private void CheckMove()
    {

        if(Input.touchCount>0)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                firstPosition=touch.position;
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Moved)
            {
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Ended)
            {
                lastPosition=touch.position;

                if(Mathf.Abs(lastPosition.x-firstPosition.x)>Mathf.Abs(lastPosition.y-firstPosition.y))
                {
                    if(lastPosition.x>firstPosition.x)
                    {
                        Debug.Log("SWIPE RIGHT");
                        GoXAxis(1);
                    }
                    else
                    {
                        Debug.Log("SWIPE LEFT");
                        GoXAxis(-1);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        Debug.Log("SWIPE UP");
                        GoZAxis(1);
                    }
                    else
                    {
                        Debug.Log("SWIPE DOWN");
                        GoZAxis(-1);
                    }
                }
            }
        }
    }

    private void GoXAxis(float direction)
    {
        var currentPosLeft=transform.position.x;
        transform.DOMoveX(currentPosLeft+direction,0.25f);
    }

    private void GoZAxis(float direction)
    {
        var currentPosUp=transform.position.z;
        transform.DOMoveZ(currentPosUp+direction,0.25f);
    }

}
