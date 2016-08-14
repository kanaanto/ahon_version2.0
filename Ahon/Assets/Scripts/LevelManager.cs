using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
	
	[System.Serializable]
	public class Level{
		public string LevelText;
		public int Unlocked;
		public bool IsInteractable;
		
		public Button.ButtonClickedEvent OnClickEvent;
	}
	public GameObject levelButton;
	public Transform Spacer;
	public List<Level> LevelList;
	
	
	
	// Use this for initialization
	void Start () {
		DeleteAll ();
		FillList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FillList(){
		foreach (var level in LevelList) {
			GameObject newbutton = Instantiate(levelButton) as GameObject;
			LevelButton button = newbutton.GetComponent<LevelButton>();
			button.LevelText.text = level.LevelText;
			
			//Level Unlock 
			if(PlayerPrefs.GetInt ("Level" + button.LevelText.text)==1){
				level.Unlocked = 1;
				level.IsInteractable = true;
			}
			
			button.unlocked = level.Unlocked;
			button.GetComponent<Button>().interactable = level.IsInteractable;
			
			newbutton.transform.SetParent(Spacer);
		}
		SaveAll();
	}
	
	void SaveAll(){
		//	if(PlayerPrefs.HasKey("Level1")){
		//		return;
		//	}else{
		
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
		foreach (GameObject buttons in allButtons){
			LevelButton button = buttons.GetComponent<LevelButton>();
			PlayerPrefs.SetInt ("Level" + button.LevelText.text, button.unlocked);
		}
	}
	//}
	
	void DeleteAll(){
		PlayerPrefs.DeleteAll ();
	}
}
