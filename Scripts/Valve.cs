using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Valve : MonoBehaviour {
    float value = 0f;

    public void setValue(float value) {
        this.value = value;
    }

    public float getValue() {
        return value;
    }
}
