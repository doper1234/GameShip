using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMapGameController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start()
    {
        spriteRenderer.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(FadeTo(0, 1.0f));
    }


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1,1,1, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
    }
    
}
