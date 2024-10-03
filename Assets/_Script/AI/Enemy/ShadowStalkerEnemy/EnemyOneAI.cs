using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyOneAI : MonoBehaviour
{
    public E1_Contronler enemyCtrl;

    public float RangeFindTarget;
    public float RangeAttack;

    public float TimeShooter;
    public float CurrentTimeShooter;    

    public BehaviorTree ShadowStaclker_AI = new BehaviorTree();

    private void Start()
    {

        E1_NodePatrol nodePatrol = new E1_NodePatrol(enemyCtrl);
        E1_NodeChase nodeCheckTarget = new E1_NodeChase(enemyCtrl, RangeAttack);
        E1_NodeShooter Shooter = new E1_NodeShooter(enemyCtrl);

        SelectorNode RootNode = new SelectorNode
        {
            childrens = { nodePatrol, nodeCheckTarget, Shooter }
        };

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
        Gizmos.DrawWireSphere(enemyCtrl.transform.position, RangeFindTarget);
    }
    #endregion

}


