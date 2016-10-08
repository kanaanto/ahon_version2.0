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
        Animator floodAnimator;
        public GameObject gameOverPanel;
        public GameObject successPanel;

        void Start()
		{
            hasCalamityStarted = false;
            calamityTimeRemaining = 30;
            calamityTimeToComplete = 10;
            playerTransform = GameObject.Find("Flood").GetComponent<Transform>();
            floodAnimator = playerTransform.gameObject.GetComponent<Animator>();
        }

		void Update()
		{
            if (calamityTimeRemaining > 0.0f)
            {

                calamity.fillAmount = Mathf.MoveTowards(calamity.fillAmount, 1.0f, (Time.deltaTime / calamityTimeRemaining) / 4f);
                calamityTimeRemaining -= Time.deltaTime;
            }
            else
            {
                if (calamityTimeToComplete > 0.0f)
                {
                    int checker_1 = (int)calamityTimeToComplete;

                    duration.fillAmount = Mathf.MoveTowards(duration.fillAmount, 1.0f, (Time.deltaTime / calamityTimeToComplete) / 4f);
                    calamityTimeToComplete -= Time.deltaTime;
                    //Debug.Log("calamityTimeToComplete - " + calamityTimeToComplete);

                    int checker_2 = (int)calamityTimeToComplete;
                    if (checker_1 != checker_2 && !hasCalamityStarted)
                    {
                        hasCalamityStarted = true;
                        StartFlood();
                    }

                }
                else
                {
                    EndFlood();
                    ShowGameOverPanel("success");
                }
            }
        }
        public void StartFlood()
        {
            floodAnimator.runtimeAnimatorController = Resources.Load("Flood") as RuntimeAnimatorController;
        }

        public void EndFlood()
        {
            floodAnimator.runtimeAnimatorController = null;
        }

        public void ShowGameOverPanel(string type)
        {
            if (type.Equals("success"))
            {
                //gameOver = transform.FindChild("PanelGameOver").gameObject as GameObject;
                //gameOver = GameObject.Find("PanelPause").GetComponent<GameObject>();
                successPanel.SetActive(true);
            } else
            {
                gameOverPanel.SetActive(true);
            }

        }

    }
}

