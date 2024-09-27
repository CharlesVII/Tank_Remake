using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode
{
    public override void NodeOnStart()
    {
    }

    public override void NodeOnStop()
    {
    
    }

    public override STATE NodeOnUpdate()
    {
        child.NodeUpdate();
        return STATE.RUNNING;
    }
}
