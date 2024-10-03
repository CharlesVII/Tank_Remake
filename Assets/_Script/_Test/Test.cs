using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IDetectablePLayer
{
    public void OnDetected()
    {
        Debug.Log("Bị phát hiện");
    }

}
