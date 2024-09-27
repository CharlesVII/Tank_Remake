using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePatrol : ActionNode
{
    private EnemyCtrl enemyCtrl;
    private Transform Target;

    public NodePatrol(EnemyCtrl enemyCtrl)
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
        Debug.Log("Tuan tra");
    
        enemyCtrl.enemyMovement.MovingWithUpdateTime();
        return STATE.RUNNING;
    }
}
