using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    public void OnClickSunButton()
    {
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, GameObject.Find("Sun").transform.position + (Vector3.forward * 200f), 1f);
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Sun").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        ShipController shipController = GameObject.Find("Main Camera").GetComponent<ShipController>();
        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Sun";
    }

    public void OnClickEarthButton()
    {
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, GameObject.Find("Earth").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Earth").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        ShipController shipController = GameObject.Find("Main Camera").GetComponent<ShipController>();
        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Earth";
    }

    public void OnClickMoonButton()
    {
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, GameObject.Find("Moon").transform.position + (Vector3.forward * 3f), 1f);
        GameObject.Find("Main Camera").transform.LookAt(GameObject.Find("Moon").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        ShipController shipController = GameObject.Find("Main Camera").GetComponent<ShipController>();
        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Moon";

        transform.parent.parent.Find("MoonInfoPanel").gameObject.SetActive(true);
    }
}
