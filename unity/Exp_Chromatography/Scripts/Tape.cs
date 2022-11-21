using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Tape : GrabbableEvents
{
    public bool isAttached = false;
    public bool isGripped = false;
    private Color defaultColor;
    MeshRenderer mr;

    private void Start()
    {
        mr = gameObject.GetComponentInChildren<MeshRenderer>();
        defaultColor = mr.material.color;
        mr.material.color = new Color(0, 0, 0, 0);
    }

    public override void OnGrip(float gripValue)
    {
        isGripped = true;
        if (!isAttached)
            mr.material.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
    }

    public void AttachTape()
    {
        isAttached = true;
    }
}
