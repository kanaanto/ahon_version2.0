using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	int score = 1000;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level1_score", score);
		StartCoroutine (Time ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator Time(){
		yield return new WaitForSeconds (5f);
		Application.LoadLevel (1);
	}
}
