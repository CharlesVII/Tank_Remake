using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyMovement : MonoBehaviour
{
    public float SpeedMoving;
    public EnemyCtrl EnemyCtrl;

    private void Start()
    {
        setRotation(Quaternion.Euler(0, 0, 45));
    }

    private void Update()
    {
        
    }


    public void setRotation(quaternion RotationEnemy)
    {
        EnemyCtrl.transform.rotation = RotationEnemy;
    }

    public void MovingWithUpdateTime()
    {
        EnemyCtrl.transform.Translate(SpeedMoving * new Vector3(0, 1, 0) * Time.deltaTime);

    }

    public void MovingWithFixUpdateTime()
    {
        EnemyCtrl.transform.Translate(SpeedMoving * new Vector3(0, 1, 0) * Time.fixedDeltaTime);
    }
}
