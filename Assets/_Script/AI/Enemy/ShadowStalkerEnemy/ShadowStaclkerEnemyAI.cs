using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShadowStaclkerEnemyAI : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;

    public float RangeCheckTarget;
    public float RangeAttack;
    public Transform Target;

    public BehaviorTree ShadowStaclker_AI = new BehaviorTree();

    private void Start()
    {
        NodePatrol nodePatrol = new NodePatrol(enemyCtrl);
        NodeCheckTarget nodeCheckTarget = new NodeCheckTarget(enemyCtrl, Target, RangeCheckTarget);
        NodeChaseTarget nodeChaseTarget = new NodeChaseTarget();

        SequencerNode patrolSequence = new SequencerNode();
        patrolSequence.childrens.Add(nodePatrol);
        patrolSequence.childrens.Add(nodeCheckTarget);

        SequencerNode AttackSequence = new SequencerNode();
        AttackSequence.childrens.Add(nodeChaseTarget);

        SelectorNode RootNode = new SelectorNode();
        RootNode.childrens.Add(patrolSequence);
        RootNode.childrens.Add(AttackSequence);

        ShadowStaclker_AI.RootNode = RootNode;
    }

    private void Update()
    {
        ShadowStaclker_AI.TreeUpdate();
    }

    private void FixedUpdate()
    {
        //ShadowStaclker_AI.TreeUpdate();
    }


    #region representational drawing
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyCtrl.transform.position, RangeAttack);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyCtrl.transform.position, RangeCheckTarget);
    }
    #endregion

}


