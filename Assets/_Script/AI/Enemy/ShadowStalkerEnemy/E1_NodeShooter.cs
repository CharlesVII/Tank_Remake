using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_NodeShooter : ActionNode
{
    public E1_Contronler enemyControler;

    public E1_NodeShooter(E1_Contronler enemyControler)
    {
        this.enemyControler = enemyControler;
    }

    public override void NodeOnStart()
    {
        enemyControler.enemyShooter.Shooter();
    }

    public override void NodeOnStop()
    {

    }

    public override STATE NodeOnUpdate()
    {
        if (enemyControler.enemyShooter.isShooter)
        {
            enemyControler.enemyShooter.Shooter();
            return STATE.RUNNING;
        }
        return STATE.SUCCESS;
    }

 
}
