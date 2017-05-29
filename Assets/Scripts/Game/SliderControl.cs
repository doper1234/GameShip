﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {

    public float levelSpeed = 0.1f;
    private Slider slider;
    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += levelSpeed;
    }
}
