using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Contronler : MonoBehaviour
{
    //Property
    public EnemyMovement enemyMovement;
    public EnemyShooter enemyShooter;
    public EnemyModel enemyModel;

    public Transform Target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Target != null)
            return;
        
        IDetectablePLayer FindTarget = collision.GetComponent<IDetectablePLayer>();
        if (FindTarget != null)
        {
            // Gán Target
            Target = collision.transform;
        }
    }

}
