using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//script c/o Elisa

public class MenuController : MonoBehaviour {

	//Panels
	public GameObject aboutM, audioM, cinematicsM, helpM, mainM, settingsM; 

	//Menus
	public enum menu {about, audio, cinematics, help, main, settings}; 
	public menu current;

	void Start()
	{
		//if !newPlayer
		current = menu.main;
		//if newPlayer, then current = menu.cinematics;
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

}
