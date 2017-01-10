using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour {
    float value;

    /// <summary>
    /// value = power level
    /// </summary>
    /// <param name="value"></param>
    public void setValue(float value) {
        this.value = value;
    }


    public float getValue() {
        return value;
    }
}
