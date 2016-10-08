using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Behaviour
{
	public class ClickResource : MonoBehaviour {
		
		public Button buildButton, plantButton;
        public GameObject plantScoreBar;
        public GameObject peopleScoreBar;
        public GameObject buildScoreBar;

        private float basePlantScore, basePeopleScore, baseBuildScore = 21;
        private int currentBuildIndex = 0;
		private int currentPlantIndex = 0;
		
		[SerializeField]
		GameObject[] build;
		
		[SerializeField]
		GameObject[] plant;
		
		public void Build()
		{
			currentBuildIndex = (currentBuildIndex + 1) % build.Length;
			//currentBuildIndex += 1;
			//currentBuildIndex++;
			build[currentBuildIndex].SetActive(true);
            ManipulateScore("build");
            ManipulateScore("people");
            if (currentBuildIndex == build.Length)
			{
				buildButton.interactable = false;
			}
		}
		
		public void Plant()
		{
			currentPlantIndex = (currentPlantIndex + 1) % plant.Length;
			//currentPlantIndex += 1;
			//currentPlantIndex++;
			plant[currentPlantIndex].SetActive(true);
            ManipulateScore("plant");

            if (currentPlantIndex == plant.Length)
			{
				plantButton.interactable = false;
			}
		}


        public void ManipulateScore(string type)
        {
            switch (type)
            {
                case "plant":
                    if (basePlantScore < 140)
                    {
                        basePlantScore += 11.9f;
                        RectTransform rt = plantScoreBar.transform as RectTransform;
                        rt.sizeDelta = new Vector2(basePlantScore, 24);
                    }
                    break;
                case "people":

                    if (basePeopleScore < 140)
                    {
                        basePeopleScore += 11.9f;
                        RectTransform rt = peopleScoreBar.transform as RectTransform;
                        rt.sizeDelta = new Vector2(basePeopleScore, 24);
                    }
                    break;
                case "build":
                    if (baseBuildScore < 140)
                    {
                        baseBuildScore += 11.9f;
                        RectTransform rt = buildScoreBar.transform as RectTransform;
                        rt.sizeDelta = new Vector2(baseBuildScore, 24);
                    }
                    break;
            }

        }
    }
}

