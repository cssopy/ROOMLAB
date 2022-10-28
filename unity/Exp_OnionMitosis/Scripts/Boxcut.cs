using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcut : MonoBehaviour
{
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        Material capMaterial = gameObject.GetComponent<MeshRenderer>().material;
        GameObject[] gameObjects = MeshCut.Cut(gameObject, transform.position, Vector3.forward, capMaterial);
        GameObject[] leftSide = MeshCut.Cut(gameObject, transform.position, Vector3.left, capMaterial);
        GameObject[] rightSide = MeshCut.Cut(gameObject, transform.position, Vector3.down, capMaterial);
        gameObjects[0].transform.position += Vector3.up * 1;
        gameObjects[1].transform.position += Vector3.down * 1;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
