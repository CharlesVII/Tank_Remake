using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AimIndicator : MonoBehaviour
{
    public Vector3 DirectionMousePos = Vector3.zero; 

    public Transform TowerTank;
    public PlayerCtrl PlayerCtrl;
    public SpriteRenderer Sprite_For_Tower;
    public SpriteRenderer Sprite_For_Mouse;

    public Color color_Default;
    public Color color_isCanShooter;


    private void Start()
    {
        TowerTank = PlayerCtrl.playerModel.Tower;

        if (TowerTank == null) Debug.LogError("Haven't See Tower In");
    }

    private void Update()
    {
        RotationAndFollow();
        ChangeColor();
    }

    public void RotationAndFollow()
    {
        transform.position = PlayerCtrl.transform.position;

        DirectionMousePos = InputPlayer.Instance.MousePointPosition - Sprite_For_Mouse.transform.position;
        float angle = Mathf.Atan2(DirectionMousePos.y, DirectionMousePos.x) * Mathf.Rad2Deg;
        Sprite_For_Mouse.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        Sprite_For_Tower.transform.rotation = TowerTank.rotation;
    }

    public void ChangeColor()
    {
   
        if (Mathf.Abs(Sprite_For_Tower.transform.rotation.eulerAngles.z - Sprite_For_Mouse.transform.rotation.eulerAngles.z) > 5)
        {
            Sprite_For_Tower.color = color_Default;
            Sprite_For_Mouse.color = color_Default;
        }
        else
        {
            Sprite_For_Tower.color = color_isCanShooter;
            Sprite_For_Mouse.color = color_isCanShooter;
        }
    }
}
