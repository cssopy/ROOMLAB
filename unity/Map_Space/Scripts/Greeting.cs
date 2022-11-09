using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : MonoBehaviour
{
    public AudioClip audioClip;
    private TTSManager tts;

    void Awake()
    {
        tts = GameObject.Find("TTSManager").GetComponent<TTSManager>();
    }

    void Start()
    {
        AddSound();
    }

    public void AddSound()
    {
        if (audioClip != null)
        {
            tts.AddSound(audioClip, "Greeting");
        }
    }
}
