using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldObstacle : Obstacleable
{
    // Generate Etmek Gerekir. Gold lari.

    [SerializeField] private int increaseAmount;

    [SerializeField] private GameObject goldEffect;
    void Start()
    {
        increaseAmount=Random.Range(10,50);
    }
    internal override void DoAction(Player player)
    {
        gameObject.SetActive(false);
        ScoreManager.Instance.UpdateScore(increaseAmount);
        Instantiate(goldEffect,transform.position,Quaternion.identity);
    }
}
