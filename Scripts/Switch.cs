﻿using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    float value = 0f;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() { 

    }

    public void setValue(float value) {
        this.value = value;
    }

    public float getValue() {
        return value;
    }
    public void show() { 
        
    }
}