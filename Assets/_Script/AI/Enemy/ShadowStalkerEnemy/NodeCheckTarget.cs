using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCheckTarget : ActionNode
{
    public EnemyCtrl enemyCtrl;
    public Transform target;
    public float rangeCheckTarget;

    public NodeCheckTarget(EnemyCtrl enemyCtrl,Transform target, float rangeCheckTarget)
    {
        this.enemyCtrl = enemyCtrl;
        this.target = target;
        this.rangeCheckTarget = rangeCheckTarget;
    }

    public override void NodeOnStart()
    {
       
    }

    public override void NodeOnStop()
    {
       
    }

    public override STATE NodeOnUpdate()
    {
        if (target == null)
            return STATE.FAILURE;

        Debug.Log("check");

        float Distance = Vector3.Distance(enemyCtrl.transform.position, target.position);
        if(Distance < rangeCheckTarget)
        {
            return STATE.SUCCESS;
        }
        return STATE.FAILURE;
    }
}
