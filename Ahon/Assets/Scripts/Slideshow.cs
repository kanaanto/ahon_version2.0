using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour {

	Image splashImage;
	Canvas splashCanvas;
	
	[SerializeField]
	Sprite[] images;
	
	[SerializeField]
	float fadeTime, displayTime, transparentTime;
	
	public MenuController skip;
	//	int i;
	
	int currentImage = 0;
	
	
	void OnEnable ()
	{
		//		splashCanvas = GetComponent<Canvas> ();
		//		if (splashCanvas.worldCamera != Camera.main)
		//		{
		//			splashCanvas.worldCamera = Camera.main;
		//		}
		
		//		DontDestroyOnLoad (gameObject);
		
		splashImage = GetComponentInChildren<Image> ();
		splashImage.sprite = images [currentImage];
		StartCoroutine (Cinematics ());
	}
	
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			skip.OnCinematicsClose();	
		}
	}
	
	IEnumerator Cinematics ()
	{
		for ( int i = 0; i < images.Length; i++)
		{
			splashImage.sprite = images [i];
			
			splashImage.color = new Color (splashImage.color.r, splashImage.color.g, splashImage.color.b, 0);
			yield return new WaitForSeconds (transparentTime);
			
			//Fade in
			for (float alpha = 0; alpha < 1; alpha += Time.deltaTime / fadeTime) 
			{
				splashImage.color = new Color (splashImage.color.r, splashImage.color.g, splashImage.color.b, alpha);
				yield return null;
			}
			
			yield return new WaitForSeconds (displayTime);
			
			//Fade out
			for (float alpha = 1; alpha > 1; alpha -= Time.deltaTime / fadeTime)
			{
				splashImage.color = new Color (splashImage.color.r, splashImage.color.g, splashImage.color.b, alpha);
				yield return null;
			}
		}
		skip.OnCinematicsClose ();
	}
}