using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPlanet : MonoBehaviour {

    private bool messageShown = false;
    private Scene planetQuestionScene;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!messageShown && collision.tag == "Player")
        {
            SceneManager.LoadScene("Enter Planet Question", LoadSceneMode.Additive);
            messageShown = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.UnloadSceneAsync("Enter Planet Question");
            messageShown = false;
        }
    }
}
