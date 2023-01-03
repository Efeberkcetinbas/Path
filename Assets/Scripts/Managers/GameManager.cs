using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("About Player")]
    public GameObject Player;
    public Vector3 PlayerStartPosition;
    public Vector3 FinishPosition;
    public bool canPlayerJump;


    public float ProgressValue;
    public float finishLineZ;

    [Header("Game Ending")]
    public GameObject successPanel;
    public GameObject failPanel;
    public bool isGameEnd=false;




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
        Player.transform.position=PlayerStartPosition;
        Player.transform.rotation=Quaternion.identity;
        ProgressValue=0;
        UIManager.Instance.UpdateProgressBar(0);
        successPanel.SetActive(false);
        failPanel.SetActive(false);
        StartCoroutine(DeactiveGameEnd());
       //
    }

    private IEnumerator DeactiveGameEnd()
    {
        yield return new WaitForSeconds(.5f);
        isGameEnd=false;
    }

    public void Open(GameObject gameObjects)
    {
        gameObjects.SetActive(true);
    }

   

    


    
}
