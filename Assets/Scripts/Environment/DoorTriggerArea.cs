using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : Obstacleable
{
    public int id;

    internal override void DoAction(Player player)
    {
        GameEvents.Instance.DoorwayTriggerEnter(id);
    }

    internal override void InteractionExit(Player player)
    {
        GameEvents.Instance.DoorwayTriggerExit(id);
    }
    
}
