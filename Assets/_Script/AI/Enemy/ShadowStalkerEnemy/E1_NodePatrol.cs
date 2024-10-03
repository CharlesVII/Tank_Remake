using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class E1_NodePatrol : ActionNode
{
    private E1_Contronler enemyCtrl;
    public E1_NodePatrol(E1_Contronler enemyCtrl)
    {
        this.enemyCtrl = enemyCtrl;
    }

    public override void NodeOnStart()
    {
        
    }

    public override void NodeOnStop()
    {

    }

    public override STATE NodeOnUpdate()
    {
        if (enemyCtrl.Target == null) 
        {
            enemyCtrl.enemyMovement.MovingRandom(Time.deltaTime);
            return STATE.RUNNING;
        }
        return STATE.FAILURE;

    }
}
