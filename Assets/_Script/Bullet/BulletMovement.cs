using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private BulletCtrl bulletCtrl;
    [SerializeField] public bool isMovement;
    [SerializeField] protected float Speed_Bullet;
    [SerializeField] protected Vector3 vectorDirection = Vector3.zero;

    private void OnEnable()
    {

    }

    private void FixedUpdate()
    {
        BulletMoving();
    }

    public void SetDirection(Vector3 DicretionShoot)
    {
        vectorDirection = DicretionShoot.normalized;

        float angle = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90);
        bulletCtrl.transform.rotation = targetRotation;

        isMovement = true;
        bulletCtrl.trailRendererl.Clear();
    }

    protected void BulletMoving()
    {
        if (!isMovement)
            return;
        bulletCtrl.transform.Translate(Vector2.up * Speed_Bullet * Time.fixedDeltaTime);
    }
}
