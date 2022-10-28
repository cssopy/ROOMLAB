using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotton : MonoBehaviour
{
    public bool isBurning = false;
    public bool isBurned = false;
    public string type = null;
    
    public GameObject grains;
    public GameObject fire;

    private Grains grainsComp;
    private Fire fireComp;

    private void Awake()
    {
        grainsComp = grains.GetComponent<Grains>();
        fireComp = fire.GetComponent<Fire>();
    }

    private void Update()
    {
        if (isBurning)
        {
            grainsComp.onFire();
            fire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flame")
        {
            if(type == "Na")
            {
                fireComp.setFireColor(Color.yellow);
            }else if (type == "Cu")
            {
                fireComp.setFireColor(new Color(0, 255, 255));
            }
            else if (type == "Sr")
            {
                fireComp.setFireColor(Color.red);
            }
            else if (type == "Ba")
            {
                fireComp.setFireColor(new Color(60, 66, 23));
            }
            else if (type == "K")
            {
                fireComp.setFireColor(new Color(139, 0, 255));
            }
            isBurning = true;
        }
    }
}
