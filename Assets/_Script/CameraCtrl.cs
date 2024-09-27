using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Player;
    public float speedFollow;

    void Update()
    {
        CameraFollowPLayer();
    }

    private void FixedUpdate()
    {
        
    }

    public void CameraFollowPLayer()
    {
        Vector3 TargetCamera = Player.transform.position;
        TargetCamera.z = Camera.main.transform.position.z;
      
        transform.position =  Vector3.Lerp(transform.position, TargetCamera, speedFollow * Time.deltaTime);
    }
}
