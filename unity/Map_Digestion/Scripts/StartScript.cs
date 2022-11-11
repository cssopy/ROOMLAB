using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Start;
        Start = Resources.Load("Experiment/CombineCottonFoil") as GameObject;
        Instantiate(Start, Start.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private const float inchToCm = 2.54f;
    [SerializeField]
    private EventSystem eventSystem = null;
    [SerializeField]
    private float dragThresholdCM = 0.5f;
    //For drag Threshold
    private void SetDragThreshold()
    {
        if (eventSystem != null)
        {
            eventSystem.pixelDragThreshold = (int)(dragThresholdCM * Screen.dpi / inchToCm);
        }

    }

    void Awake()
    {
        SetDragThreshold();
    }


}
