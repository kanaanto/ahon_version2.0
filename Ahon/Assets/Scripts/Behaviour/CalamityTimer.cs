using UnityEngine;
using System;
using UnityEngine.UI;

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
        bool hasCalamityStarted;
        private Transform playerTransform;
        public Animator floodAnimator;
        public GameObject gameOverPanel;
        public GameObject successPanel;
		public GameObject goalPanel;

		private static bool isGameSuccess;
		bool goalClosed;
		bool isFlooding;

        void Start()
		{
            hasCalamityStarted = false;
			goalClosed = false;
			isFlooding = false;
			isGameSuccess = false;
            calamityTimeRemaining = 15;
            calamityTimeToComplete = 10;
            playerTransform = GameObject.Find("Flood").GetComponent<Transform>();
            floodAnimator = playerTransform.gameObject.GetComponent<Animator>();
        }

		void Update()
		{
			if (goalClosed)
			{
				if (calamityTimeRemaining > 0.0f) {
					calamity.fillAmount = Mathf.MoveTowards (calamity.fillAmount, 1.0f, (Time.deltaTime / calamityTimeRemaining) / 4f);
					calamityTimeRemaining -= Time.deltaTime;
				} else {
					if (calamityTimeToComplete > 0.0f) {
						int checker_1 = (int)calamityTimeToComplete;

						duration.fillAmount = Mathf.MoveTowards (duration.fillAmount, 1.0f, (Time.deltaTime / calamityTimeToComplete) / 4f);
						calamityTimeToComplete -= Time.deltaTime;
						//Debug.Log("calamityTimeToComplete - " + calamityTimeToComplete);

						int checker_2 = (int)calamityTimeToComplete;
						if (checker_1 != checker_2 ) {
							hasCalamityStarted = true;
							StartFlood ();
						}

					} else {
						EndFlood ();
						isGameSuccess = Boolean.Parse(PlayerPrefs.GetString("GameSuccess"));

						if(isGameSuccess){
							ShowGameOverPanel ("success");
						} else {
							ShowGameOverPanel ("-1");
						}
					}
				}
			}
        }
        public void StartFlood()
        {
			isFlooding = true;
			//floodAnimator.runtimeAnimatorController = Resources.Load("Flood") as RuntimeAnimatorController;
			floodAnimator.Play ("flood");
        }

        public void EndFlood()
        {
			isFlooding = false;
			//floodAnimator.runtimeAnimatorController = null;
			floodAnimator.enabled = false;
        }

        public void ShowGameOverPanel(string type)
        {
			int peopleScore = PlayerPrefs.GetInt("PeopleScore");
			int plantScore = PlayerPrefs.GetInt("PlantScore");
			int buildScore = PlayerPrefs.GetInt("BuildScore");
			int totalScore = PlayerPrefs.GetInt("TotalScore");
            if (type.Equals("success"))
            {
                //gameOver = transform.FindChild("PanelGameOver").gameObject as GameObject;
                //gameOver = GameObject.Find("PanelPause").GetComponent<GameObject>();
                successPanel.SetActive(true);
			
				Text peopleScoreText = GameObject.Find("SuccessPeopleScore").GetComponent<Text>();
				peopleScoreText.text = peopleScore.ToString();
				Text plantScoreText = GameObject.Find("SuccessPlantScore").GetComponent<Text>();
				plantScoreText.text = plantScore.ToString();
				Text buildScoreText = GameObject.Find("SuccessBuildScore").GetComponent<Text>();
				buildScoreText.text = buildScore.ToString();
				Text totalScoreText = GameObject.Find("SuccessTotalScore").GetComponent<Text>();
				totalScoreText.text = totalScore.ToString();

            } else
            {
                gameOverPanel.SetActive(true);
				Text totalScoreText = GameObject.Find("FailTotalScore").GetComponent<Text>();
				totalScoreText.text = totalScore.ToString();
            }
        }

		public void closeGoal()
		{
			goalPanel.SetActive (false);
			goalClosed = true;
		}

    }
}

