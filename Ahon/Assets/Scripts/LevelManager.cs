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

			newbutton.transform.SetParent(Spacer);
		}
	}
}
