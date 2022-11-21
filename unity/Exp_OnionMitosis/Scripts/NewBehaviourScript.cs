using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class handle : MonoBehaviour
{
    float rightHandRotationY()
    {
        float yValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).y;
        float wValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).w;

        if (wValue >= 0)
        {
            return -Mathf.Abs(yValue);
        }
        else
        {
            return Mathf.Abs(yValue);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
