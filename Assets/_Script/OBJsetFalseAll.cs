using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJsetFalseAll : MonoBehaviour
{
    private void Start()
    {
        setFalse();
    }

    public void setFalse()
    {
        foreach(Transform i in transform)
        {
            i.gameObject.SetActive(false);
        }
    }
}
