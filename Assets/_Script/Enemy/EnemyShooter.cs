using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float TimeShoot;
    public float CurrentTime;

    public Transform Target;
    public GameObject PrefabBullet;

    private void OnEnable()
    {
        CurrentTime = TimeShoot + 1;
    }

    public void Shooter()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime < TimeShoot)
            return;

        Debug.Log("Shooter");
        CurrentTime = 0;

    }

}
