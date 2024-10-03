using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_NodeChase : ActionNode
{
    public E1_Contronler enemyCtrl;

    public float RangeShooter;

    public E1_NodeChase(E1_Contronler enemyCtrl, float rangeShooter)
    {
        this.enemyCtrl = enemyCtrl;
        RangeShooter = rangeShooter;
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
            return STATE.SUCCESS;

        float DistanceTarget = Vector3.Distance(enemyCtrl.transform.position, enemyCtrl.Target.position);
        if( DistanceTarget >= RangeShooter)
        {
            enemyCtrl.enemyMovement.ChaseTarget(Time.deltaTime, enemyCtrl.Target);
            return STATE.RUNNING;
        }
        
        return STATE.FAILURE;
    }
}
