using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Text titleText, pressStartText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(FadeToTransition(1, 1.0f));
            StartCoroutine(FadeTo(0, 1.0f));
        }
	}


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = titleText.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(titleText.color.r, titleText.color.g, titleText.color.b, Mathf.Lerp(alpha, aValue, t));
            titleText.color = newColor;
            pressStartText.color = newColor;
            yield return null;
        }
    }

    IEnumerator FadeToTransition(float aValue, float aTime)
    {
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
        SceneManager.LoadScene("Space Map", LoadSceneMode.Single);
    }
}
