using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerCtrl playerCtrl;

    [SerializeField] private float TimeShootMachineGun;
    [SerializeField] private float TimeShootArtilleryGun;
    [SerializeField] private float CurrentTime_MachineGun = 0;
    [SerializeField] private float CurrentTime_ArtilleryGun = 0;

    [SerializeField] private GameObject Prefab_MachineGun;
    [SerializeField] private GameObject Prefab_ArtilleryGun;
    public Transform tower;

    // Update is called once per frame
    void Update()
    {
        MachineGunShooter();
        ArtilleryGunShooter();
    }

    private void ArtilleryGunShooter()
    {
        CurrentTime_ArtilleryGun += Time.deltaTime;
        if (CurrentTime_ArtilleryGun < TimeShootArtilleryGun)
            return;

        if (!InputPlayer.Instance.MouseRightPress)
        {
            CurrentTime_ArtilleryGun = 2 * TimeShootArtilleryGun;
            return;
        }

        BulletCtrl NewBullet = Spawn.Instance.SpawnOBJ(Prefab_ArtilleryGun, playerCtrl.playerModel.PointArtilleryGun.position).GetComponent<BulletCtrl>();

        NewBullet.bulletMovement.SetDirection(tower.up);

        CurrentTime_ArtilleryGun = 0;
    }

    private void MachineGunShooter()
    {
        CurrentTime_MachineGun += Time.deltaTime;
        if (CurrentTime_MachineGun < TimeShootMachineGun)
            return;
        if (!InputPlayer.Instance.MouseLeftPress)
        {
            CurrentTime_MachineGun = 2 * TimeShootMachineGun;
            return;
        }

        BulletCtrl NewBullet = Spawn.Instance.SpawnOBJ(Prefab_MachineGun, playerCtrl.playerModel.PointMachineGun.position).GetComponent<BulletCtrl>();

        NewBullet.bulletMovement.SetDirection(tower.up);

        CurrentTime_MachineGun = 0;
    }
}
