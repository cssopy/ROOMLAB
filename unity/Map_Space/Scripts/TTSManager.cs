using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSManager : MonoBehaviour
{
	public class TTSSound
	{
		public AudioClip sound;
		public string soundType;
	}

	private AudioClip playingSound;
	private string playingSoundType;
	public List<TTSSound> waitingSoundList = new List<TTSSound>();

	private AudioSource _audioSource;

	public static TTSManager instance = null;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		_audioSource = this.gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		if (playingSound != null)
		{
			PlaySound();
		}
		else
		{
			LoadSound();
		}
	}

	void PlaySound()
	{
		if (!_audioSource.isPlaying)
        {
			_audioSource.PlayOneShot(playingSound);
			playingSound = null;
        }
	}

	public void AddSound(AudioClip audioClip, string soundType)
	{
		if (soundType == "Mode")
        {
			if (waitingSoundList.Count <= 0)
            {
				if (!_audioSource.isPlaying)
                {
					waitingSoundList.Add(new TTSSound() { sound = audioClip, soundType = soundType });
				}
				else if (playingSoundType == "Mode")
                {
					_audioSource.Stop();
					waitingSoundList.Add(new TTSSound() { sound = audioClip, soundType = soundType });
				}
			}
        }
		else if (soundType == "Info")
		{
			_audioSource.Stop();
			ClearSoundList();
			waitingSoundList.Add(new TTSSound() { sound = audioClip, soundType = soundType });
		}
		else
        {
			waitingSoundList.Add(new TTSSound() { sound = audioClip, soundType = soundType });
		}
	}

	void LoadSound()
    {
		if (waitingSoundList.Count > 0 && !_audioSource.isPlaying)
        {
			playingSound = waitingSoundList[0].sound;
			playingSoundType = waitingSoundList[0].soundType;
			waitingSoundList.RemoveAt(0);
        }
	}

	public void ClearSoundList()
	{
		_audioSource.Stop();
		waitingSoundList.Clear();
	}
}
