using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyMovement : MonoBehaviour
{
    public float SpeedMoving;
    public float TimeChageRotation;
    public float CurrentTimeChageRotation;
    public float maxDistanceWithPlayer;
    public float Debuggg;
    public Vector3 TargetRotation;
    
    public E1_Contronler EnemyCtrl;

    private void Start()
    {
        //setRotation(Quaternion.Euler(0, 0, 45));
    }

    private void Update()
    {
        Debuggg = Vector2.Distance(EnemyCtrl.transform.position, Camera.main.transform.position);
    }

    public void setRotation(quaternion RotationEnemy)
    {
        EnemyCtrl.transform.rotation = RotationEnemy;
    }

    public void ChangeRotationWithTime(float deltaTime_Or_fixedDeltaTime)
    {
        CurrentTimeChageRotation += deltaTime_Or_fixedDeltaTime;
        if (CurrentTimeChageRotation < TimeChageRotation)
            return;
        do
        {

            TargetRotation = new Vector3Int(0, 0, UnityEngine.Random.Range(0, 360));
        } while (math.abs(EnemyCtrl.transform.eulerAngles.z - TargetRotation.z) > 70);
        CurrentTimeChageRotation = 0;
    }

    public void MovingRandom(float deltaTime_Or_fixedDeltaTime)
    {
        if (Vector2.Distance(EnemyCtrl.transform.position, Camera.main.transform.position) >= maxDistanceWithPlayer)
        {
            CurrentTimeChageRotation = 0;
            Vector3 direction = Camera.main.transform.position - EnemyCtrl.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            EnemyCtrl.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
        }
        else
        {
            ChangeRotationWithTime(deltaTime_Or_fixedDeltaTime);
            EnemyCtrl.transform.rotation = Quaternion.Slerp(EnemyCtrl.transform.rotation, Quaternion.Euler(TargetRotation), deltaTime_Or_fixedDeltaTime);
        }
        EnemyCtrl.transform.Translate(SpeedMoving * new Vector3(0, 1, 0) * deltaTime_Or_fixedDeltaTime);

    }

    public void ChaseTarget(float deltaTime_Or_fixedDeltaTime,Transform target)
    {
        Vector3 direction = EnemyCtrl.transform.position - target.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // EnemyCtrl.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        EnemyCtrl.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle + 90)), deltaTime_Or_fixedDeltaTime);
        EnemyCtrl.transform.Translate(SpeedMoving * new Vector3(0, 1, 0) * deltaTime_Or_fixedDeltaTime);
    }
}
