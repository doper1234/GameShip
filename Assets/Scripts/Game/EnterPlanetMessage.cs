using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterPlanetMessage : MonoBehaviour {

    private bool bYes = true;
    private bool bNo = false;

    public Color selectedColour;
    public Color deselectedColour;
    public Text messageText;
    public Image image;
    public Text textYes;
    public Text textNo;
    public SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.A))
        {
            if (bYes)
            { StartCoroutine(FadeTo(1, 1.0f));
            StartCoroutine(FadeToUI(0, 1.0f)); }
        else
            SceneManager.UnloadSceneAsync("Enter Planet Question");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bYes = true;
            bNo = false;
            textYes.color = selectedColour;
            textNo.color = deselectedColour;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bYes = false;
            bNo = true;
            textYes.color = deselectedColour;
            textNo.color = selectedColour;
        }
    }

    IEnumerator FadeToUI(float aValue, float aTime)
    {
        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(messageText.color.r, messageText.color.g, messageText.color.b, Mathf.Lerp(alpha, aValue, t));
            image.color = messageText.color = textYes.color = textNo.color =  newColor;
            
            yield return null;
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
        SceneManager.LoadScene("Planet Race", LoadSceneMode.Single);
    }
}
