using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchManager : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private float dragDistance;


    ScoreManager scoreManager;

    void Start()
    {
        dragDistance=Screen.height*15/100;
        scoreManager=ScoreManager.Instance;
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
                        JumpXAxis(+1);
                    }
                    else
                    {
                        JumpXAxis(-1);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        JumpZAxis(+1);
                        GameManager.Instance.CalculateForwardToFinish();
                    }
                    else
                    {
                        JumpZAxis(-1);
                        GameManager.Instance.CalculateBackwardToFinish();
                    }
                }
            }
        }
    }

    #region Move
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

    #endregion

    #region Jump
    private void JumpXAxis(float direction)
    {
        var currentPos=transform.position;
        transform.DOJump(new Vector3(currentPos.x+direction,currentPos.y,currentPos.z),1,1,0.25f);
        scoreManager.UpdateScore(50);
    }

    private void JumpZAxis(float direction)
    {
        var currentPos=transform.position;
        transform.DOJump(new Vector3(currentPos.x,currentPos.y,currentPos.z + direction),1,1,0.25f).OnComplete(()=>{
            //GameManager.Instance.CalculateStartToFinish();
        });
        scoreManager.UpdateScore(50);
    }
    #endregion
}
