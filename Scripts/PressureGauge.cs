using UnityEngine;
using System.Collections;

public class PressureGauge : MonoBehaviour {
    float value;

    public float getValue () {
        return value;
    }
    /// <summary>
    /// 单位 Kpa
    /// </summary>
    /// <param name="value"></param>
    public void setValue(float value) {
        this.value = value;
    }
}
