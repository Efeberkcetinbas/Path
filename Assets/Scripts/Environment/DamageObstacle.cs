using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : Obstacleable
{

    internal override void DoAction(Player player)
    {
        GameManager.Instance.Open(GameManager.Instance.failPanel);
    }
}
