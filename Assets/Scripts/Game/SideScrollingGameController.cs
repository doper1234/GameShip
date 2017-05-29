using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SideScrollingGameController : MonoBehaviour {

    public Slider slider;
    public PlayerMovementCS player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(slider.value == slider.maxValue && !player.isDead)
        {
            SceneManager.LoadScene("Planet Foot", LoadSceneMode.Single);
        }
	}
}
