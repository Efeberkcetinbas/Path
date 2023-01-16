using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessArea : Obstacleable
{
    internal override void DoAction(Player player)
    {
        CameraManager.Instance.ChangeFieldOfView(30,0.75f);
        SoundManager.Instance.Play("Success");
        GameManager.Instance.isGameEnd=true;
        StartCoroutine(OpenPanel());
    }

    private IEnumerator OpenPanel()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Open(GameManager.Instance.successPanel);
    }
}
