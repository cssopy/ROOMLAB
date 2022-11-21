using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public AudioClip closingSound;
    private TTSManager tts;
    private AudioSource _audioSource;
    
    void Start()
    {
        tts = GameObject.Find("TTSManager").GetComponent<TTSManager>();
        _audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void NavigateHome()
    {
        if (closingSound != null)
        {
            tts.AddSound(closingSound, "Closing");
        }
        //Invoke("LoadSolarMainScene", 2f);
    }
}
