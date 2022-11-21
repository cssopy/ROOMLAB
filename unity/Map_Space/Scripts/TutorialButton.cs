using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public AudioClip audioClip;
    private TTSManager tts;

    void Awake()
    {
        tts = GameObject.Find("TTSManager").GetComponent<TTSManager>();
    }

    public void AddSound()
    {
        if (audioClip != null)
        {
            tts.AddSound(audioClip, "Tutorial");
        }
    }
}
