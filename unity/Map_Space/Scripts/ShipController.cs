using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 5f, strafeSpeed = 5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 20f;
    //private Vector2 lookInput, screenCenter, mouseDistance;
    
    private float rollInput;
    public float rollSpeed = 20f, rollAcceleration = 2f;

    public bool isFlight = false;
    public bool isFocus = false;
    public string focusObject;

    AsteroidGenerator asteroidGenerator;

    float leftHandRotationY()
    {
        float yValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).y;
        float wValue = InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).w;

        if (wValue >= 0)
        {
            return -Mathf.Abs(yValue);
        }
        else
        {
            return Mathf.Abs(yValue);
        }
    }

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

    float rotationValue(float value)
    {
        if (value >= 180f)
        {
            return (value - 360f) / 180f;
        }
        else
        {
            return value / 180f;
        }
    }

    void Flight()
    {
        //lookInput.x = Input.mousePosition.x;
        //lookInput.y = Input.mousePosition.y;

        //mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        //mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, (rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).eulerAngles.z) + rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).eulerAngles.z)), rollAcceleration * Time.deltaTime);

        transform.Rotate((rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).eulerAngles.x) + rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).eulerAngles.x)) * lookRateSpeed * Time.deltaTime,
            (rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Left).eulerAngles.y) + rotationValue(InputBridge.Instance.GetControllerLocalRotation(ControllerHand.Right).eulerAngles.y)) * lookRateSpeed * Time.deltaTime,
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
        asteroidGenerator = GameObject.Find("XR Rig").GetComponent<AsteroidGenerator>();
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
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Earth")
            {
                transform.position = GameObject.Find("Earth").transform.position + (Vector3.forward * 5f);
                transform.LookAt(GameObject.Find("Earth").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Moon")
            {
                transform.position = (GameObject.Find("Moon").transform.position*4 + GameObject.Find("Earth").transform.position)/5;
                transform.LookAt(GameObject.Find("Moon").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Mercurius")
            {
                transform.position = GameObject.Find("Mercurius").transform.position + (Vector3.forward * 5f);
                transform.LookAt(GameObject.Find("Mercurius").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Venus")
            {
                transform.position = GameObject.Find("Venus").transform.position + (Vector3.forward * 5f);
                transform.LookAt(GameObject.Find("Venus").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Mars")
            {
                transform.position = GameObject.Find("Mars").transform.position + (Vector3.forward * 5f);
                transform.LookAt(GameObject.Find("Mars").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Jupiter")
            {
                transform.position = GameObject.Find("Jupiter").transform.position + (Vector3.forward * 100f);
                transform.LookAt(GameObject.Find("Jupiter").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Saturnus")
            {
                transform.position = GameObject.Find("Saturnus").transform.position + (Vector3.forward * 80f);
                transform.LookAt(GameObject.Find("Saturnus").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Uranus")
            {
                transform.position = GameObject.Find("Uranus").transform.position + (Vector3.forward * 20f);
                transform.LookAt(GameObject.Find("Uranus").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }
            else if (focusObject == "Neptunus")
            {
                transform.position = GameObject.Find("Neptunus").transform.position + (Vector3.forward * 20f);
                transform.LookAt(GameObject.Find("Neptunus").transform);
                transform.position += new Vector3(0, -1.2f, 0);
            }

            //asteroidGenerator.CreateAsteroid();
        }
    }
}
