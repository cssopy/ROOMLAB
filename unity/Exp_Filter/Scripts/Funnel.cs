using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GlassStick")
        {
            if(other.transform.eulerAngles.x > 0 && other.transform.eulerAngles.x > 90)
            {
                canvas.GetComponent<CheckForCanvas>().isGlassStickInclined = true;
                Debug.Log(other.transform.eulerAngles.x);

            } else
            {
                canvas.GetComponent<CheckForCanvas>().isGlassStickInclined = false;
            }
        }
    }
}
