using UnityEngine;

public class Compass : MonoBehaviour
{
    GameObject compassCylinder;

    private void Start()
    {
        compassCylinder = transform.Find("Compass").Find("Cylinder.001").gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lab_Table_3 (13)")
        {
            compassCylinder.GetComponent<CompassCylinder>().ChangeCylinder();
        } 
    }

}
