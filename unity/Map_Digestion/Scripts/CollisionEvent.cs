using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEvent : MonoBehaviour
{
    public GameObject Dish, Cotton;
    //public GameObject panel = GameObject.Find("Panel");

    void Start()
    {
        Dish = GameObject.Find("Dish"); //cube
        Cotton = GameObject.Find("Sphere"); // dish
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("충돌");
        Dish.SetActive(false);
        Cotton.SetActive(false);
        SceneManager.LoadScene("DropAlcohol");
        //panel.SetActive(true);

        //Invoke("Time", 1f);

        //StartCoroutine(Disabled(5.0f));

        /*
        if (collision.gameObject.tag == "Cube")

        {

            //Box Collider 인스펙터에서 Is Trigger 체크해서 활성화!

            collision.gameObject.SetActive(false);

            //Destroy(other.gameObject);

        }
        */

    }
    /*
    void Time()
    {
        panel.SetActive(false); // 다시 한 번 해바~~ 패널
    }
    */
    /*
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == "Sphere")
        {
            Debug.Log("충돌");
        }
    }

    /*

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "material_t")
        {
            Destroy(gameObject);
        }
    }
    */
}
