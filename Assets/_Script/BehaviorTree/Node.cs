using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Node
{ 
    public enum STATE
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public STATE State = STATE.RUNNING;
    public bool started = false;

    public STATE NodeUpdate()
    {
        if (!started)
        {
            NodeOnStart();
            started = true;
        }

        State = NodeOnUpdate();

        if(State == STATE.SUCCESS || State == STATE.FAILURE)
        {
            NodeOnStop();
            started = false;
        }


        return State;

    }

    public abstract void NodeOnStart();
    public abstract void NodeOnStop();
    public abstract STATE NodeOnUpdate();
}
