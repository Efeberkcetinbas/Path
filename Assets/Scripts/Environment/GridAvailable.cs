using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridAvailable : Obstacleable
{
    [SerializeField] private bool isAvailable;

    [SerializeField] private MeshRenderer mr;
    internal override void DoAction(Player player)
    {
        if(isAvailable)
        {
            mr.material.DOColor(Color.green,0.5f);
        }
        else
        {
            mr.material.DOColor(Color.red,0.5f);
            //Game Over 
        }
    }

    internal override void InteractionExit(Player player)
    {
        //
    }
}
