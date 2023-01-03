using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridAvailable : Obstacleable
{
    [SerializeField] private bool isAvailable;

    [SerializeField] private MeshRenderer mr;

    [SerializeField] private float yAxis,oldYAxis;

    [SerializeField] private ParticleSystem JumpEffect;

    internal override void DoAction(Player player)
    {
        if(isAvailable)
        {
            mr.material.DOColor(Color.green,0.5f);
            StartCoroutine(StartShake());
        }
        else
        {
            mr.material.DOColor(Color.red,0.5f);
            //Game Over 
        }
    }

    private IEnumerator StartShake()
    {
        yield return new WaitForSeconds(0.3f);
        CameraManager.Instance.ShakeIt();
        JumpEffect.Play();

    }


    internal override void InteractionExit(Player player)
    {
        transform.DOLocalMoveY(yAxis,0.25f).OnComplete(()=>transform.DOLocalMoveY(oldYAxis,0.25f));
        //
    }
}
