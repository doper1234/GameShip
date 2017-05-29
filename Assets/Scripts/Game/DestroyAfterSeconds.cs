using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float destroyInSeconds = 2;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyInSeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
