using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BehaviorTree
{
    public Node RootNode;
    public Node.STATE TreeState = Node.STATE.RUNNING;

    public Node.STATE TreeUpdate()
    {
        //if (RootNode.State == Node.STATE.RUNNING)
        //{
        //    TreeState = RootNode.NodeUpdate();
        //}
        //return TreeState;

        TreeState = RootNode.NodeUpdate();
        return TreeState;

    }
    
}
