using UnityEngine;

public class FilterCollider : MonoBehaviour
{

    private GameObject filter;

    private void Start()
    {
        filter = transform.parent.gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "GlassPlate")
        {
            filter.transform.parent.Find("FilterUnfolded").gameObject.SetActive(true);
            filter.transform.Find("Drop").gameObject.SetActive(false);
            filter.transform.Find("Liquid").gameObject.SetActive(false);
            filter.GetComponent<MeshRenderer>().enabled = false;
            filter.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
