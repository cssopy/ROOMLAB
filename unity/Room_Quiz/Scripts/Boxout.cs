using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxout : MonoBehaviour
{
    public GameObject[] gameObjects;
    public bool flag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TriggerObject")
        {
            Debug.Log("Ãæµ¹ : " + flag);
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(flag);
            }
            flag = !flag;
        }
        
    }
}
