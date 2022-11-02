using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    

    public Vector3 PlayerStartPosition;


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
    
    public void UpdateStartPos()
    {
        PlayerStartPosition=FindObjectOfType<StartPosControl>().startPos;
        Player.transform.position=PlayerStartPosition;
    }
    public void ResetTheLevel()
    {
       //
    }
}
