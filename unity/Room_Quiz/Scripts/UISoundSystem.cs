using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundSystem : MonoBehaviour
{
    public AudioSource onUI;
    public AudioSource offUI;
    public AudioSource closeLid;
    public AudioSource wrong;
    public AudioSource right;
    public AudioSource hoverBtn;
    public AudioSource onFire;
    public AudioSource burning;
    public AudioSource mountSocket;
    public AudioSource coolDown;
    public AudioSource burningAlcoholLamp;
    public AudioSource lighting;
    public AudioSource onLighter;

    public void OnUI()
    {
        onUI.Play();
    }
    public void OffUI()
    {
        offUI.Play();
    }

    public void CloseLid()
    {
        closeLid.Play();
    }

    public void Wrong()
    {
        wrong.Play();
    }

    public void Right()
    {
        right.Play();
    }

    public void HoverBtn()
    {
        hoverBtn.Play();
    }

    public void OnFire()
    {
        onFire.Play();
    }

    public void Burning()
    {
        burning.Play();
    }

    public void MountSocket()
    {
        mountSocket.Play();
    }

    public void CoolDown()
    {
        coolDown.Play();
    }

    public void BurningAlcoholLamp()
    {
        burningAlcoholLamp.Play();
    }

    public void Lighting()
    {
        lighting.Play();
    }

    public void OnLighter()
    {
        onLighter.Play();
    }
}
