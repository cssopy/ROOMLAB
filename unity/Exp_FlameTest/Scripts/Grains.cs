using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grains : MonoBehaviour
{
    public List<Grain> grainCom;

    private void Awake()
    {
        grainCom = new List<Grain>();
        for(int i=0; i<this.transform.childCount; i++)
        {
            grainCom.Add(this.transform.GetChild(i).gameObject.GetComponent<Grain>());
        }
    }

    public void onFire()
    {
        foreach(Grain grain in grainCom)
        {
            grain.onFile();
        }
    }
}
