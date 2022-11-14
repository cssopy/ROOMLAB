using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public List<Material> materials = new List<Material>();

    void Update()
    {
        transform.Rotate(new Vector3(0, -Time.deltaTime * -10f, 0));
    }

    public void SetModelMaterial(int index)
    {
        if (materials.Count > index)
        {
            gameObject.GetComponent<MeshRenderer>().material = materials[index];
        }
    }
}