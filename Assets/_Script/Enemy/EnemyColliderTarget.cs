using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderTarget : MonoBehaviour
{
    public EnemyCtrl EnemyCtrl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Find Target");
        EnemyCtrl.enemyShooter.Target = collision.transform;
    }
}
