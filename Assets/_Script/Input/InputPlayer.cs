using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : Singleton<InputPlayer>
{
    public Vector3 MousePointPosition;
    public float Horizontal;
    public float Vertical;

    public bool MouseLeftPress;
    public bool MouseRightPress;


    private void Update()
    {
        TakeValueFloat();
        TakeValuePress();
    }

    private void TakeValueFloat()
    {

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");


        MousePointPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePointPosition.z = 0;
    }

    private void TakeValuePress()
    {
        MouseLeftPress = Input.GetMouseButton(0);
        MouseRightPress = Input.GetMouseButton(1);  
    }
}
