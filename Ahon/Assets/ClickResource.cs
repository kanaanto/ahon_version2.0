using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Behaviour
{
	public class ClickResource : MonoBehaviour {
		
		public Button buildButton, plantButton;

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

			if (currentPlantIndex == plant.Length)
			{
				plantButton.interactable = false;
			}
		}
	}
}

