using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class SelectorNode : CompositeNode
{
    [SerializeField] private int Current;   
    public override void NodeOnStart()
    {
        Current = 0;
    }

    public override void NodeOnStop()
    {
        
    }

    public override STATE NodeOnUpdate()
    {
        #region Method 1
        Node child = childrens[Current];
        switch (child.NodeUpdate())
        {
            case STATE.FAILURE:
                Current++;
                break;

            case STATE.SUCCESS:
                return STATE.SUCCESS;

            case STATE.RUNNING:
                return STATE.RUNNING;
        }

        if (Current == childrens.Count)
            return STATE.FAILURE;
        else
            return STATE.RUNNING;
        #endregion

        #region Method 2
        //while(Current< childrens.Count)
        //{
        //    STATE childState = childrens[Current].NodeUpdate();

        //    if (childState == STATE.SUCCESS)
        //    {
        //        return STATE.SUCCESS;
        //    }

        //    if (childState == STATE.RUNNING)
        //    {
        //        return STATE.RUNNING;
        //    }

        //    Current++;
        //}

        //return STATE.FAILIURE;  
        #endregion
    }


}