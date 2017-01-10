using UnityEngine;
using System.Collections;

public class AirBlast : MonoBehaviour
{
    float value;

    public void setValue(float value) {
        this.value = value;
    }

    public float getValue() {
        return value;
    }
}
