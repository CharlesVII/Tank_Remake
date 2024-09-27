using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : CompositeNode
{
    int Current;
    protected override void NodeOnStart()
    {
        Current = 0;
    }

    protected override void NodeOnStop()
    {
    }

    protected override STATE NodeOnUpdae()
    {
        Node child = childrens[Current];
        switch (child.Update())
        {
            case State.FAILIURE:
                Current++;
                break;

            case State.SUCCESS:
                return State.SUCCESS;

            case State.RUNNING:
                return State.RUNNING;
        }

        if (Current == childrens.Count)
            return State.FAILIURE;
        else
            return State.RUNNING;
    }
}
