using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerTowerRotation : MonoBehaviour
{
    [SerializeField] protected Transform TowerTank;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected Vector3 vectorDirection = Vector3.zero;

    private void Update()
    {
        RotationTower();
    }

    protected void RotationTower()
    {
        Vector3 PosMouse = new Vector3(InputPlayer.Instance.MousePointPosition.x, InputPlayer.Instance.MousePointPosition.y, 0);
        vectorDirection = InputPlayer.Instance.MousePointPosition - TowerTank.position;
        vectorDirection.Normalize();

        float angle = Mathf.Atan2(vectorDirection.y, vectorDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90);
        TowerTank.rotation = Quaternion.Lerp(TowerTank.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
