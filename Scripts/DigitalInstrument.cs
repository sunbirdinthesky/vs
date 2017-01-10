using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DigitalInstrument : MonoBehaviour {
    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}

    public void setValue(float value) {
        text.text = string.Format("{0:000.0}", value);
    }
}
