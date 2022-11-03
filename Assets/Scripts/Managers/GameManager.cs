using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    

    public Vector3 PlayerStartPosition;
    public Vector3 FinishPosition;

    public float ProgressValue;
    public float finishLineZ;

    public bool canPlayerJump;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    private void UpdateStartPos()
    {
        PlayerStartPosition=FindObjectOfType<StartPosControl>().startPos;
        Player.transform.position=PlayerStartPosition;
    }

    private void UpdateFinishPos()
    {
        FinishPosition=FindObjectOfType<FinishLinePos>().FLinePosition;
        finishLineZ=FindObjectOfType<FinishLinePos>().finishZ;
    }

    public void UploadAllUpdates()
    {
        UpdateStartPos();
        UpdateFinishPos();
    }

    public void CalculateForwardToFinish()
    {
        ProgressValue+=1/(float)finishLineZ;
        UIManager.Instance.UpdateProgressBar(ProgressValue);
    }

    public void CalculateBackwardToFinish()
    {
        ProgressValue-=1/(float)finishLineZ;
        UIManager.Instance.UpdateProgressBar(ProgressValue);
    }

    public void ResetTheLevel()
    {
       //
    }
}
