using UnityEngine;
using System.Collections;

public class GamePlay : MonoBehaviour {
    //Goal UI
    GameObject[] goal;
    public Animator slideInGoal;
    private Transform playerTransform;

    // Use this for initialization
    void Start () {
        goal = GameObject.FindGameObjectsWithTag("Goal");
       // slideInGoal = GameObject.FindGameObjectsWithTag("PanelGoal");
        StartCoroutine(ShowGoal());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        (GetComponent("CalamityTimer") as MonoBehaviour).enabled = true;
        CloseGoalPanel();
    }
    public void CloseGoalPanel()
    {
        foreach (GameObject g in goal)
        {
            g.SetActive(false);
        }
    }

    public IEnumerator ShowGoal()
    {
        yield return new WaitForSeconds(0.1f);
        slideInGoal.SetTrigger("StartGoal");
        foreach (GameObject g in goal)
        {
            g.SetActive(true);
        }
        yield return null;
    }

    public void StartCalamity()
    {
        playerTransform = GameObject.Find("Flood").GetComponent<Transform>();
        //playerTransform = GetComponent("Flood") as Transform;
        Debug.Log(playerTransform);
        Animator animator = playerTransform.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Flood") as RuntimeAnimatorController;
        Debug.Log(animator.runtimeAnimatorController);
    }
    
}
