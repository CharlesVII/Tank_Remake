using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class SequencerNode : CompositeNode
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
        Node Child = childrens[Current];
        switch (Child.NodeUpdate())
        {

            case STATE.RUNNING:
                return STATE.RUNNING;

            case STATE.FAILURE:
                return STATE.FAILURE;

            case STATE.SUCCESS:
                Current++;
                break;

        }

        if (Current == childrens.Count)
            return STATE.SUCCESS;
        else
            return STATE.RUNNING;
        #endregion

        #region Method 2
        //while (Current < childrens.Count)
        //{
        //    STATE childState = childrens[Current].NodeUpdate();

        //    if (childState == STATE.FAILIURE)
        //    {
        //        return STATE.FAILIURE;
        //    }

        //    if(childState == STATE.RUNNING)
        //    {
        //        return STATE.RUNNING;
        //    }    

        //    Current++;
        //}
        //return STATE.SUCCESS;
        #endregion

    }
}
