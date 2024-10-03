using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float TimeShoot;
    public float CurrentTime;
    public float TimeAniShooter;
    public float CurrentTimeAniShooter;
    public bool isShooter;

    public GameObject PrefabBullet;
    public E1_Contronler EnemyControler;

    private void OnEnable()
    {
        CurrentTime = TimeShoot + 1;
    }

    public void Shooter()
    {
        isShooter = true;
        CurrentTime += Time.deltaTime;
        if (CurrentTime < TimeShoot)
            return;


        CurrentTimeAniShooter += Time.deltaTime;

        if (CurrentTimeAniShooter > TimeAniShooter)
        {
            Debug.Log("Shooter");
            Spawn.Instance.SpawnOBJ(PrefabBullet, EnemyControler.enemyModel.PointShoot.position);

            CurrentTimeAniShooter = 0;
            CurrentTime = 0;
            isShooter = false;
        }

    }

}
