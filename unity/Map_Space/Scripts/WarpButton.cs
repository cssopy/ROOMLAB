using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpButton : MonoBehaviour
{
    ShipController shipController;

    public List<GameObject> infoPanels = new List<GameObject>();


    void Start()
    {
        shipController = GameObject.Find("XR Rig").GetComponent<ShipController>();
    }

    void InfoPanelReset()
    {
        for (int i = 0; i < 10; i++)
        {
            infoPanels[i].SetActive(false);
        }
    }

    public void OnClickSunButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Sun").transform.position + (Vector3.forward * 200f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Sun").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Sun";
    }

    public void OnClickEarthButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Earth").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Earth").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Earth";
    }

    public void OnClickMoonButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Moon").transform.position + (Vector3.forward * 3f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Moon").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Moon";

        //transform.parent.parent.Find("MoonInfoPanel").gameObject.SetActive(true);
    }

    public void OnClickMercuriusButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Mercury").transform.position + (Vector3.forward * 1f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Mercury").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Mercury";
    }

    public void OnClickVenusButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Venus").transform.position + (Vector3.forward * 1f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Venus").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Venus";
    }

    public void OnClickMarsButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Mars").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Mars").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Mars";
    }

    public void OnClickJupiterButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Jupiter").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Jupiter").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Jupiter";
    }

    public void OnClickSaturnusButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Saturn").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Saturn").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Saturn";
    }

    public void OnClickUranusButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Uranus").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Uranus").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Uranus";
    }

    public void OnClickNeptunusButton()
    {
        InfoPanelReset();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("XR Rig").transform.position = Vector3.Lerp(GameObject.Find("XR Rig").transform.position, GameObject.Find("Neptunus").transform.position + (Vector3.forward * 5f), 1f);
        GameObject.Find("XR Rig").transform.LookAt(GameObject.Find("Neptunus").transform);
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Clear();
        GameObject.Find("Star Particle").GetComponent<ParticleSystem>().Play();

        shipController.isFocus = true;
        shipController.isFlight = false;
        shipController.focusObject = "Neptunus";
    }
}
