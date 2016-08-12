using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
//script c/o Elisa

public class MenuController : MonoBehaviour {

	//Panels
	public GameObject aboutM, audioM, cinematicsM, helpM, mainM, settingsM; 

	//Menus
	public enum menu {about, audio, cinematics, help, main, settings}; 
	public menu current;

	//Audio
	public AudioMixer masterMixer;
	public AudioMixerSnapshot masterOff, masterOn, sfxOff, sfxOn, cinematics;
	bool masterAudioOn = true;
	bool soundfxOn = true;
	float BGVolValue, SFXVolValue;
	public AudioSource mainMusic;


	void Start()
	{
		//if !newPlayer
		current = menu.main;
		//if newPlayer, then current = menu.cinematics;
		mainMusic.Play ();
	}

	void Update()
	{
		switch (current)
		{
		case menu.about:
			aboutM.SetActive(true);
			audioM.SetActive(false);
			cinematicsM.SetActive(false);
			helpM.SetActive(false);
			mainM.SetActive(false);
			settingsM.SetActive(true);
			break;
		case menu.audio:
			aboutM.SetActive(false);
			audioM.SetActive(true);
			cinematicsM.SetActive(false);
			helpM.SetActive(false);
			mainM.SetActive(false);
			settingsM.SetActive(true);
			break;
		case menu.cinematics:
			aboutM.SetActive(false);
			audioM.SetActive(false);
			cinematicsM.SetActive(true);
			helpM.SetActive(false);
			mainM.SetActive(false);
			settingsM.SetActive(false);
			break;
		case menu.help:
			aboutM.SetActive(false);
			audioM.SetActive(false);
			cinematicsM.SetActive(false);
			helpM.SetActive(true);
			mainM.SetActive(false);
			settingsM.SetActive(true);
			break;
		case menu.main:
			aboutM.SetActive(false);
			audioM.SetActive(false);
			cinematicsM.SetActive(false);
			helpM.SetActive(false);
			mainM.SetActive(true);
			settingsM.SetActive(false);
			break;
		case menu.settings:
			aboutM.SetActive(false);
			audioM.SetActive(true);
			cinematicsM.SetActive(false);
			helpM.SetActive(false);
			mainM.SetActive(false);
			settingsM.SetActive(true);
			break;
		}
	}

	public void OnStartScene()
	{
		current = menu.main;
	}

	public void OnAboutClick()
	{
		current = menu.about;
	}

	public void OnAudioClick()
	{
		current = menu.audio;
	}

	public void OnCinematicsClick()
	{
		current = menu.cinematics;
		cinematics.TransitionTo (0.01f);
	}

	public void OnHelpClick()
	{
		current = menu.help;
	}

	public void OnSettingsClick()
	{
		current = menu.settings;
	}
	public void OnPlayClick()
	{
		Application.LoadLevel (1);
	}

	public void MuteMasterAudio()
	{
		if (masterAudioOn)
		{
			masterOff.TransitionTo (0.01f);
			masterAudioOn = false;
			Debug.Log("Background Music is off");
		}
		else
		{
			masterOn.TransitionTo(0.01f);
			masterAudioOn = true;
			Debug.Log("Background Music is on");
		}
		Debug.Log ("BGVol value is " + BGVolValue);
	}

	public void MuteSfxAudio()
	{
		if (soundfxOn)
		{
			sfxOff.TransitionTo (0.01f);
			soundfxOn = false;
		}
		else
		{
			sfxOn.TransitionTo(0.01f);
			soundfxOn = true;
		}
		Debug.Log ("SFXVol value is " + SFXVolValue); 
	}

	public void OnCinematicsClose()
	{
		if (masterAudioOn)
		{
			masterOn.TransitionTo (0.01f);
			masterAudioOn = true;
			Debug.Log("Background Music is on");
		}
		else
		{
			masterOff.TransitionTo (0.01f);
			masterAudioOn = false;
			Debug.Log("Background Music is off");
		}
		Debug.Log ("BGVol value is " + BGVolValue);

		if (soundfxOn)
		{
			sfxOn.TransitionTo (0.01f);
			soundfxOn = true;
			Debug.Log("Sound Effects is on");
		}
		else
		{
			sfxOff.TransitionTo (0.01f);
			soundfxOn = false;
			Debug.Log("Sound Effects is off");
		}
		Debug.Log ("SFXVol value is " + SFXVolValue); 
		current = menu.main;
	}
}
