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
                        //Debug.Log("SWIPE RIGHT");
                        JumpXAxis(+1.2f);
                        //GoXAxis(1.2f);
                    }
                    else
                    {
                        //Debug.Log("SWIPE LEFT");
                        JumpXAxis(-1.2f);
                        //GoXAxis(-1.2f);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        //Debug.Log("SWIPE UP");
                        JumpZAxis(+1.2f);
                        //GoZAxis(1.2f);
                    }
                    else
                    {
                        //Debug.Log("SWIPE DOWN");
                        JumpZAxis(-1.2f);
                        //GoZAxis(-1.2f);
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

    private void JumpXAxis(float direction)
    {
        var currentPos=transform.position;
        transform.DOJump(new Vector3(currentPos.x+direction,currentPos.y,currentPos.z),1,1,0.25f);
    }

    private void JumpZAxis(float direction)
    {
        var currentPos=transform.position;
        transform.DOJump(new Vector3(currentPos.x,currentPos.y,currentPos.z + direction),1,1,0.25f);
    }

}
