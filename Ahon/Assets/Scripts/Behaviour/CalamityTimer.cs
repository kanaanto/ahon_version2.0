using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Classes;
using Assets.Scripts.DataSource;
//c/o Elisa

namespace Assets.Scripts.Behaviour
{
	class CalamityTimer : MonoBehaviour
	{
		//Calamity UI
		public float calamityTimeRemaining; //NOTE: in original project, this value is fetched from the database
		public float calamityTimeToComplete; //NOTE: in original project, this value is fetched from the database
		public Image calamity;
		public Image duration;

		//Goal UI
		GameObject[] goal;
		public Animator slideInGoal;


		void Start()
		{
			goal = GameObject.FindGameObjectsWithTag ("Goal");
			StartCoroutine (ShowGoal ());
		}

		void Update()
		{
			if (calamityTimeRemaining > 0.0f)
			{
				calamity.fillAmount = Mathf.MoveTowards(calamity.fillAmount, 1.0f, (Time.deltaTime / calamityTimeRemaining) / 4f);
				calamityTimeRemaining -= Time.deltaTime;
			}
		}

		public IEnumerator ShowGoal()
		{
			yield return new WaitForSeconds (0.1f);
			slideInGoal.SetTrigger ("StartGoal");
			foreach (GameObject g in goal)
			{
				g.SetActive(true);
			}
			yield return null;
		}
		
		public void closeGoal()
		{
			foreach (GameObject g in goal) 
			{
				g.SetActive(false);
			}
		}
	}
}

