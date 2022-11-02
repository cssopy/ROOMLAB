using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 50f, strafeSpeed = 5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2.0f;

    public float lookRateSpeed = 90f;
    //private Vector2 lookInput, screenCenter, mouseDistance;
    
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 2.5f;

    public bool isFlight = false;
    public bool isFocus = false;
    public string focusObject;

    float leftHandRotationY()
    {
        float yValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).y;

        if (yValue >= -0.5 && yValue <= 0.5)
        {
            return yValue;
        }
        else
        {
            return 0;
        }
    }

    float rightHandRotationY()
    {
        float yValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).y;

        if (yValue >= -0.5 && yValue <= 0.5)
        {
            return yValue;
        }
        else
        {
            return 0;
        }
    }

    void Flight()
    {
        //lookInput.x = Input.mousePosition.x;
        //lookInput.y = Input.mousePosition.y;

        //mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        //mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).z, rollAcceleration * Time.deltaTime);

        transform.Rotate((InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).x + InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).x) * lookRateSpeed * Time.deltaTime,
            (leftHandRotationY() + rightHandRotationY()) * lookRateSpeed * Time.deltaTime,
            rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, (InputBridge.Instance.LeftGrip - InputBridge.Instance.RightGrip) * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
        
    }

    void Start()
    {
        //screenCenter.x = Screen.width * .5f;
        //screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputBridge.Instance.AButton)
        {
            isFlight = !isFlight;
        }

        if (isFlight) {
            Flight();
        }
        else if (isFocus)
        {
            if (focusObject == "Sun")
            {
                transform.position = GameObject.Find("Sun").transform.position + (Vector3.forward * 200f);
                transform.LookAt(GameObject.Find("Sun").transform);
            }
            else if (focusObject == "Earth")
            {
                transform.position = GameObject.Find("Earth").transform.position + (Vector3.forward * 5f);
                transform.LookAt(GameObject.Find("Earth").transform);
            }
            else if (focusObject == "Moon")
            {
                transform.position = (GameObject.Find("Moon").transform.position*5 + GameObject.Find("Earth").transform.position)/6;
                transform.LookAt(GameObject.Find("Moon").transform);
            }
        }
    }
}
