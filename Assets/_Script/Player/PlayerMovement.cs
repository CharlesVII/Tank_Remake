using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotation;

    [SerializeField] private PlayerCtrl playerCtrl;
    private void Update()
    {
        rotationTank();
        movementTank();
    }


    private void rotationTank()
    {
        if (InputPlayer.Instance.Horizontal != 0)
        {
            //Debug.Log(speedRotation * InputMN.Instance.Input_Horizontal * Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(0, 0, -InputPlayer.Instance.Horizontal * speedRotation * Time.deltaTime);
            playerCtrl.transform.Rotate(deltaRotation.eulerAngles);
        }
    }

    private void movementTank()
    {
        if (InputPlayer.Instance.Vertical != 0)
        {
            playerCtrl.transform.Translate(Vector2.up * speedMovement * InputPlayer.Instance.Vertical * Time.deltaTime);
        }

    }
}
