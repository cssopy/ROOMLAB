using UnityEngine;
using BNG;

public class Pincette : GrabbableEvents
{
    public string handType;
    [SerializeField]
    private GameObject filter;
    private GameObject filterTrigger1;
    private GameObject filterTrigger2;

    private void Start()
    {
        filterTrigger1 = filter.transform.Find("FilterTriggerPoint1").gameObject;
        filterTrigger2 = filter.transform.Find("FilterTriggerPoint2").gameObject;
    }

    public override void OnTriggerDown()
    {
        transform.Find("Renderer").transform.localScale = new Vector3(1, 1, 0.3f);
        if (filterTrigger1.GetComponent<FilterTrigger>().pincetteEntered && filterTrigger2.GetComponent<FilterTrigger>().pincetteEntered)
        {
            filter.GetComponent<Filter>().filterTriggered = true;
        } else
        {
            filter.GetComponent<Filter>().filterTriggered = false;
        }
    }

    public override void OnTriggerUp()
    {
        transform.Find("Renderer").transform.localScale = new Vector3(1, 1, 1);
        filter.GetComponent<Filter>().filterTriggered = false;
    }


}
