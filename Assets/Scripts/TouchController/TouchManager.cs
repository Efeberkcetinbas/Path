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
    GameManager gameManager;

    [SerializeField] private Animator animator;

    void Start()
    {
        dragDistance=Screen.height*15/100;
        scoreManager=ScoreManager.Instance;
        gameManager=GameManager.Instance;
    }

    void Update()
    {
        if(gameManager.canPlayerJump)
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
                        gameManager.canPlayerJump=false;
                        RotateYAxis(90);
                        //Rotate
                        JumpXAxis(+1);
                        animator.SetBool("Jump",true);
                    }
                    else
                    {
                        gameManager.canPlayerJump=false;
                        JumpXAxis(-1);
                        RotateYAxis(-90);
                        animator.SetBool("Jump",true);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        gameManager.canPlayerJump=false;
                        JumpZAxis(+1);
                        RotateYAxis(0);
                        animator.SetBool("Jump",true);
                        GameManager.Instance.CalculateForwardToFinish();
                    }
                    else
                    {
                        gameManager.canPlayerJump=false;
                        JumpZAxis(-1);
                        RotateYAxis(180);
                        animator.SetBool("Jump",true);
                        GameManager.Instance.CalculateBackwardToFinish();
                    }
                }
            }
        }
    }

    private IEnumerator JumpToFalse()
    {
        yield return new WaitForSeconds(1);
        gameManager.canPlayerJump=true;
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
        transform.DOJump(new Vector3(currentPos.x+direction,currentPos.y,currentPos.z),1,1,1f).OnComplete(()=>{
            animator.SetBool("Jump",false);
            StartCoroutine(JumpToFalse());
        });
        scoreManager.UpdateScore(50);
    }

    private void JumpZAxis(float direction)
    {
        var currentPos=transform.position;
        transform.DOJump(new Vector3(currentPos.x,currentPos.y,currentPos.z + direction),1,1,1).OnComplete(()=>{
            animator.SetBool("Jump",false);
            StartCoroutine(JumpToFalse());
            //GameManager.Instance.CalculateStartToFinish();
        });
        scoreManager.UpdateScore(50);
    }
    #endregion

    #region  Rotate
    private void RotateYAxis(float y)
    {
        transform.DORotate(new Vector3(0,y,0),0.25f);
    }

    #endregion
}
